using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkService.Helpers;
using NetworkService.Models;
using NetworkService.Views;

namespace NetworkService.ViewModel
{
    public class NetworkEntitiesViewModel : BindableBase
    {
        // TODO prepravi filter u pretragu
        /*
        public Reaktor selectedDevice;
        public int idTb;
        public string nameTb;
        public string typeCb;
        public int idFilterTb;
        public string typeFilterCb;
        public List<Reaktor> ReaktoriTemp;
        public bool greaterThan;
        public bool lessThan;
        public bool equal;
        */

        public Reaktor selectedDevice;

        // Za novog
        public int idTb;
        public string nameTb;

        // Za pretragu
        public string typeCb;
        public int idFilterTb;
        public string typeFilterCb;
        public List<Reaktor> ReaktoriTemp;
        public List<Reaktor> ReaktoriPretraga;

        public bool pretragaNaziv;
        public bool pretragaTip;
        public string kriterijumPretrage;

        // Tabela
        public NetworkEntitiesViewModel()
        {
            Tipovi = new ObservableCollection<string>();
            Tipovi.Add("RTU");
            Tipovi.Add("Termosprega");

            if (Reaktori == null)
            {
                Reaktori = new ObservableCollection<Reaktor>();
            }

            // Komande
            AddCommand = new MyICommand(OnAdd);
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
            PretragaCommand = new MyICommand(onPretraga, CanFilter);
            RemovePretragaCommand = new MyICommand(RemovePretraga);
        }

        public ObservableCollection<string> Tipovi { get; set; }
        public static ObservableCollection<Reaktor> SviReaktori { get; set; }
        public static ObservableCollection<Reaktor> Reaktori { get; set; }

        public MyICommand AddCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand PretragaCommand { get; set; }
        public MyICommand RemovePretragaCommand { get; set; }


        #region PROPERTIJI - NOVI REAKTOR
        // Za novi reaktor
        public int IdTb
        {
            get { return idTb; }

            set
            {
                if (idTb != value)
                {
                    idTb = value;
                    OnPropertyChanged("IdTb");
                }
            }
        }

        // Za novi reaktor
        public string NameTb
        {
            get { return nameTb; }

            set
            {
                if (nameTb != value)
                {
                    nameTb = value;
                    OnPropertyChanged("NameTb");
                }
            }
        }

        // Za novi reaktor
        public string TypeCb
        {
            get { return typeCb; }

            set
            {
                if (typeCb != value)
                {
                    typeCb = value;
                    OnPropertyChanged("TypeCb");
                }
            }
        }

        public Reaktor SelectedDevice
        {
            get { return selectedDevice; }

            set
            {
                if (selectedDevice != value)
                {
                    selectedDevice = value;
                    DeleteCommand.RaiseCanExecuteChanged();

                }
            }
        }
        #endregion

        #region PROPERTIJI - PRETRAGA
        public bool PretragaNaziv
        {
            get { return pretragaNaziv; }

            set
            {
                if (pretragaNaziv != value)
                {
                    pretragaNaziv = value;
                    OnPropertyChanged("PretragaNaziv");
                }
            }
        }

        public bool PretragaTip
        {
            get { return pretragaTip; }

            set
            {
                if (pretragaTip != value)
                {
                    pretragaTip = value;
                    OnPropertyChanged("PretragaTip");
                }
            }
        }

        public string KriterijumPretrage
        {
            get { return kriterijumPretrage; }

            set
            {
                if (kriterijumPretrage != value)
                {
                    kriterijumPretrage = value;
                    OnPropertyChanged("KriterijumPretrage");
                }
            }
        }
        #endregion

        #region AKCIJE - DODAVANJE, BRISANJE
        private void OnAdd()
        {
            Reaktor novi = new Reaktor 
            { 
                Id = IdTb, 
                Ime = NameTb, 
                Tip = new Tip { Naziv = TypeCb, Slika = "" }, 
                Vrednost = 0 
            };
            AddReaktor(novi);
        }

        private void AddReaktor(Reaktor novi)
        {
            SviReaktori.Add(novi);
            Reaktori = SviReaktori;
        }

        private void OnDelete()
        {
            SviReaktori.Remove(SelectedDevice);
            Reaktori = SviReaktori;
        }

        private bool CanDelete()
        {
            return SelectedDevice != null;
        }
        #endregion

        #region AKCIJE - PRETRAGA
        // PRETRAGA - NAZIV I TIP
        private void onPretraga()
        {
            switch (TipPretrage())
            {
                // TODO tip
                case "TipEntiteta":
                    {
                        ReaktoriPretraga = Reaktori.Where(r => r.Tip.Naziv.Contains(KriterijumPretrage)).ToList();
                        Reaktori.Clear();

                        foreach (Reaktor r in ReaktoriPretraga)
                        {
                            Reaktori.Add(r);
                        }

                        break;
                    }
                    
                // TODO Naziv
                case "NazivEntiteta":
                    {
                        ReaktoriPretraga = Reaktori.Where(r => r.Ime.Contains(KriterijumPretrage)).ToList();
                        Reaktori.Clear();

                        foreach (Reaktor r in ReaktoriPretraga)
                        {
                            Reaktori.Add(r);
                        }

                        break;
                    }

                // TipPretrage == "Svi"
                default:
                    break;
            }
        }

        private bool CanFilter()
        {
            return (ReaktoriTemp == null || ReaktoriTemp.Count() == 0);
        }

        private string TipPretrage()
        {
            string mode = "";
            
            // TODO

            return mode;
        }

        private void RemovePretraga()
        {
            Reaktori = SviReaktori;

            if (ReaktoriTemp != null)
            {
                ReaktoriTemp.Clear();
                PretragaCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion
    }
}
