using NetworkService.Helpers;
using NetworkService.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetworkService.ViewModel
{
    public enum Actions { NO_ACTION, ADD, DELETE, WINDOW_CHANGED };

    public class MainWindowViewModel : BindableBase
    {
        #region NAVIGACIJA
        public MyICommand<string> NavCommand { get; private set; }
        #endregion

        #region VIEWMODELI
        public HomeViewModel homeViewModel;
        public NetworkEntitiesViewModel entitiesViewModel;
        public MeasurementGraphViewModel graphsViewModel;
        public static NetworkDisplayViewModel displayViewModel;
        #endregion

        #region KONSTRUKTOR
        public MainWindowViewModel()
        {
            // Povezivanje sa serverskom aplikacijom
            createListener();

            // Navigacija
            NavCommand = new MyICommand<string>(OnNav);

            // Pogledi
            homeViewModel = new HomeViewModel();
            entitiesViewModel = new NetworkEntitiesViewModel();
            graphsViewModel = new MeasurementGraphViewModel();
            displayViewModel = new NetworkDisplayViewModel();

            // Undo action
            //undoCommand = new MyICommand(OnUndo);

            // Početna je home
            CurrentViewModel = homeViewModel;
        }
        #endregion

        #region POGLEDI
        private BindableBase currentViewModel;

        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }

        private void OnNav(string destination)
        {
            UndoDestinations.Add(destination);

            switch (destination)
            {
                case "home":
                    CurrentViewModel = homeViewModel;
                    break;
                case "entities":
                    CurrentViewModel = entitiesViewModel;
                    break;
                case "display":
                    CurrentViewModel = displayViewModel;
                    break;
                case "graphs":
                    CurrentViewModel = graphsViewModel;
                    break;
            }
        }
        #endregion

        #region BRISANJE
        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Reaktor newEntity in e.NewItems)
                {
                    if (!NetworkDisplayViewModel.NetworkServiceDevices.Contains(newEntity))
                    {
                        NetworkDisplayViewModel.NetworkServiceDevices.Add(newEntity);
                    }
                }
            }

            if (e.OldItems != null)
            {
                foreach (Reaktor oldEntity in e.OldItems)
                {
                    if (NetworkDisplayViewModel.NetworkServiceDevices.Contains(oldEntity))
                    {
                        NetworkDisplayViewModel.NetworkServiceDevices.Remove(oldEntity);
                    }
                    else
                    {
                        int canvasIndex = NetworkDisplayViewModel.GetCanvasIndexForEntityId(oldEntity.Id);
                        NetworkDisplayViewModel.DeleteEntityFromCanvas(oldEntity);
                    }
                }
            }
        }
        #endregion

        #region MERENJA - NE DIRAJ (OSIM ONOGA ŠTO MORAŠ)
        private void createListener()
        {
            var tcp = new TcpListener(IPAddress.Any, 25565);
            tcp.Start();

            var listeningThread = new Thread(() =>
            {
                while (true)
                {
                    var tcpClient = tcp.AcceptTcpClient();
                    ThreadPool.QueueUserWorkItem(param =>
                    {
                        // Prijem poruke
                        NetworkStream stream = tcpClient.GetStream();
                        string incomming;
                        byte[] bytes = new byte[1024];
                        int i = stream.Read(bytes, 0, bytes.Length);

                        // Primljena poruka je sačuvana u incomming stringu
                        incomming = System.Text.Encoding.ASCII.GetString(bytes, 0, i);

                        // Ukoliko je primljena poruka pitanje koliko objekata ima u sistemu -> odgovor
                        if (incomming.Equals("Need object count"))
                        {
                            // Response
                            //Byte[] data = System.Text.Encoding.ASCII.GetBytes(count.ToString());
                            Byte[] data = System.Text.Encoding.ASCII.GetBytes(NetworkEntitiesViewModel.SviReaktori.Count().ToString());
                            stream.Write(data, 0, data.Length);
                        }
                        else
                        {
                            // U suprotnom, server je poslao promenu stanja nekog objekta u sistemu
                            Console.WriteLine(incomming); // Na primer: "Entitet_1:272"

                            //################ IMPLEMENTACIJA ####################
                            // Obraditi poruku kako bi se dobile informacije o izmeni
                            // Azuriranje potrebnih stvari u aplikaciji

                            string incomingId = incomming.Substring(incomming.IndexOf('_') + 1, 1);
                            int rbr = int.Parse(incomingId);
                            int entityId = NetworkEntitiesViewModel.SviReaktori[rbr].Id;
                            double value = double.Parse(incomming.Substring(incomming.IndexOf(':') + 1));

                            foreach (Reaktor d in NetworkEntitiesViewModel.SviReaktori)
                            {
                                if (entityId == d.Id)
                                {
                                    d.Vrednost = value;

                                    using (StreamWriter sr = File.AppendText("Log.txt"))
                                    {
                                        DateTime dateTime = DateTime.Now;
                                        sr.WriteLine($"{dateTime},{d.Id},{value}");
                                    }

                                    break;
                                }
                            }
                        }
                    }, null);
                }
            });

            listeningThread.IsBackground = true;
            listeningThread.Start();
        }
        #endregion

        #region UNDO
        private MyICommand undoCommand;
        public MyICommand UndoCommand { get; set; }

        // Destination
        private List<string> UndoDestinations = new List<string>();

        private void OnUndoNav()
        {
            if (UndoDestinations.Count > 1)
            {
                string destination = UndoDestinations.ElementAt(UndoDestinations.Count - 2);
                
                switch (destination)
                {
                    case "home":
                        CurrentViewModel = homeViewModel;
                        break;
                    case "entities":
                        CurrentViewModel = entitiesViewModel;
                        break;
                    case "display":
                        CurrentViewModel = displayViewModel;
                        break;
                    case "graph":
                        CurrentViewModel = graphsViewModel;
                        break;
                }
                UndoDestinations.RemoveAt(UndoDestinations.Count - 1);
            }
        }

        //public static Object LastAction { get; set; }
        //public static Actions LastActionId { get; set; }

        //private void OnUndoAction()
        //{
        //    if (LastAction != null && LastActionId != Actions.NO_ACTION)
        //    {
        //        if (LastActionId == Actions.ADD)
        //        {
        //            entitiesViewModel.UndoAdd((Entity)LastAction);
        //        }
        //        if (LastActionId == Actions.DELETE)
        //        {
        //            entitiesViewModel.UndoDelete((Entity)LastAction);
        //        }
        //        if (LastActionId == Actions.WINDOW_CHANGED)
        //        {
        //            CurrentViewModel = (BindableBase)LastAction;
        //        }
        //    }

        //    LastAction = null;
        //    LastActionId = Actions.NO_ACTION;
        //}

        //private void OnSetMenuEntities()
        //{
        //    LastAction = CurrentViewModel;
        //    LastActionId = Actions.WINDOW_CHANGED;
        //    CurrentViewModel = entitiesViewModel;
        //}

        //private void OnSetMenuDisplay()
        //{
        //    LastAction = CurrentViewModel;
        //    LastActionId = Actions.WINDOW_CHANGED;
        //    CurrentViewModel = displayViewModel;
        //}

        //private void OnSetMenuGraph()
        //{
        //    LastAction = CurrentViewModel;
        //    LastActionId = Actions.WINDOW_CHANGED;

        //    CurrentViewModel = graphsViewModel;
        //}

        #endregion
    }
}
