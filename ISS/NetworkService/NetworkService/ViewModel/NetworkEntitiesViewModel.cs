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
        #region PRETRAGA I DODAVANJE - POLJA
        public int idTb;
        public string nameTb;
        public string typeCb;
        public bool pretragaPoTipu;
        public bool pretragaPoNazivu;
        public string kriterijumPretrage;

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

        public bool PretragaPoTipu
        {
            get { return pretragaPoTipu; }

            set
            {
                if (pretragaPoTipu != value)
                {
                    pretragaPoTipu = value;
                    OnPropertyChanged("PretragaPoTipu");
                }
            }
        }

        public bool PretragaPoNazivu
        {
            get { return pretragaPoNazivu; }

            set
            {
                if (pretragaPoNazivu != value)
                {
                    pretragaPoNazivu = value;
                    OnPropertyChanged("PretragaPoNazivu");
                }
            }
        }
        #endregion

        #region SELEKTOVANI REAKTOR
        // SELEKTOVANI
        private Reaktor selectedDevice;
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

        // TRENUTNI
        public Reaktor currentDevice = new Reaktor();
        public Reaktor CurrentDevice
        {
            get { return currentDevice; }
            set
            {
                if (currentDevice != value)
                {
                    currentDevice = value;
                    OnPropertyChanged("CurrentDevice");
                }
            }
        }

        // TIP TRENUTNOG
        public Tip currentDeviceType = new Tip();
        public Tip CurrentDeviceType
        {
            get { return currentDeviceType; }
            set
            {
                if (currentDeviceType != value)
                {
                    currentDeviceType = value;
                    OnPropertyChanged("CurrentDeviceType");
                }
            }
        }
        #endregion

        #region KOLEKCIJE I KOMANDE
        public ObservableCollection<string> Tipovi { get; set; }
        public static ObservableCollection<Reaktor> SviReaktori { get; set; }
        public static ObservableCollection<Reaktor> ReaktoriPretraga { get; set; }

        public MyICommand AddCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand PretragaCommand { get; set; }
        public MyICommand RemovePretragaCommand { get; set; }
        #endregion

        #region KONSTRUKTOR
        public NetworkEntitiesViewModel()
        {
            Tipovi = new ObservableCollection<string>();
            Tipovi.Add("RTU");
            Tipovi.Add("Termosprega");

            if (ReaktoriPretraga == null)
            {
                ReaktoriPretraga = new ObservableCollection<Reaktor>();
            }
            if (SviReaktori == null)
            {
                SviReaktori = new ObservableCollection<Reaktor>();
            }

            // Komande
            AddCommand = new MyICommand(OnAdd);
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
            PretragaCommand = new MyICommand(OnPretraga, CanPretraga);
            RemovePretragaCommand = new MyICommand(RemovePretraga);
        }
        #endregion

        #region PRETRAGA
        public void PretragaTip()
        {
            string pvalue = KriterijumPretrage.Trim().ToLower();
            ReaktoriPretraga.Clear();

            foreach (Reaktor reaktor in SviReaktori)
            {
                if (reaktor.Tip.NazivTipa.ToLower().Contains(pvalue))
                {
                    ReaktoriPretraga.Add(reaktor);
                }
            }
        }

        public void PretragaNaziv()
        {
            string pvalue = KriterijumPretrage.Trim().ToLower();
            ReaktoriPretraga.Clear();

            foreach (Reaktor reaktor in SviReaktori)
            {
                if (reaktor.Ime.ToLower().Contains(pvalue))
                {
                    ReaktoriPretraga.Add(reaktor);
                }
            }
        }
        #endregion

        #region AKCIJE - MODIFIKACIJA
        private void OnAdd()
        {
            int parsedId;
            bool canParse = int.TryParse(CurrentDevice.TextId, out parsedId);
            bool idAlreadyExists = false;

            if (canParse)
            {
                foreach (Reaktor r in SviReaktori)
                {
                    if (r.Id == parsedId)
                    {
                        idAlreadyExists = true;
                        break;
                    }
                }
            }

            CurrentDevice.IdExists = idAlreadyExists;

            CurrentDevice.Validate();
            CurrentDeviceType.Validate();

            if (CurrentDevice.IsValid && CurrentDeviceType.IsValid)
            {
                Tip type = null;
                if (CurrentDeviceType.NazivTipa.Equals("RTD"))
                {
                    type = new Tip() { NazivTipa = CurrentDeviceType.NazivTipa, SlikaTipa = "Assets/rtd.png" };
                }
                else
                {
                    // System.Uri("/Assets/sprega.png", UriKind.Relative)
                    type = new Tip() { NazivTipa = CurrentDeviceType.NazivTipa, SlikaTipa = "Assets/sprega.png" };
                }
                Reaktor reaktor = new Reaktor { Id = Int32.Parse(CurrentDevice.TextId), Ime = CurrentDevice.Ime, Tip = type, Vrednost = 0 };
                AddReaktor(reaktor);
            }
        }

        private void AddReaktor(Reaktor novi)
        {
            SviReaktori.Add(novi);

            ReaktoriPretraga.Clear();
            foreach (Reaktor r in SviReaktori)
            {
                ReaktoriPretraga.Add(r);
            }
        }

        private void OnDelete()
        {
            SviReaktori.Remove(SelectedDevice);
            
            ReaktoriPretraga.Clear();
            foreach (Reaktor r in SviReaktori)
            {
                ReaktoriPretraga.Add(r);
            }
        }

        private bool CanDelete()
        {
            return SelectedDevice != null;
        }
        #endregion

        #region AKCIJE - PRETRAGA
        private void OnPretraga()
        {
            ReaktoriPretraga.Clear();

            if (PretragaPoTipu)
                PretragaTip();
            else 
                PretragaNaziv();
        }

        private bool CanPretraga()
        {
            // TODO: fix
            //return ((PretragaPoNazivu || PretragaPoTipu) && KriterijumPretrage.Trim().Length > 0 && SviReaktori.Count() > 0);
            return true;           
        }

        private void RemovePretraga()
        {
            ReaktoriPretraga.Clear();

            foreach (Reaktor r in SviReaktori)
            {
                ReaktoriPretraga.Add(r);
            }

            PretragaCommand.RaiseCanExecuteChanged();   
        }
        #endregion
    }
}
