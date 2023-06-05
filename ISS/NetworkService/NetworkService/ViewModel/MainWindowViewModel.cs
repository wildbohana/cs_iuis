using NetworkService.Helpers;
using NetworkService.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        #region TRENUTNO PRIKAZAN VIEWMODEL
        private BindableBase currentViewModel;
        #endregion

        #region LISTA I BROJ MREZNIH ENTITETA
        public static ObservableCollection<Reaktor> PosmatraniReaktori { get; set; }
        #endregion

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
            //undoAction = new MyICommand(OnUndoAction);

            CurrentViewModel = homeViewModel;
        }

        #region VIEWS
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

                            foreach (Reaktor r in NetworkEntitiesViewModel.SviReaktori)
                            {
                                if (entityId == r.Id)
                                {
                                    r.Vrednost = value;

                                    using (StreamWriter sr = File.AppendText("../../Log.txt"))
                                    {
                                        DateTime dateTime = DateTime.Now;
                                        sr.WriteLine($"{dateTime},{r.Id},{value}");
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

        // Ovo nije urađeno !!
        #region UNDO
        //private MyICommand undoAction;
        //public MyICommand UndoAction { get; set; }

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
