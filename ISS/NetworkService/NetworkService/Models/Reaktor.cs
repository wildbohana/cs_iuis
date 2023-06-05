using NetworkService.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static NetworkService.Models.Reaktor;

namespace NetworkService.Models
{
    //public class DataBase
    //{
    //    public static ObservableCollection<Reaktor> Reaktori { get; set; } = new ObservableCollection<Reaktor>();
    //    public static Dictionary<string, Reaktor> CanvasObjekti { get; set; } = new Dictionary<string, Reaktor>();
    //}

    public class Reaktor : ValidationBase
    {
        private string textId;

        private int id;
        private string ime;
        private Tip tip;
        private double vrednost;

        #region PROPERTIJI
        public string TextId
        {
            get { return textId; }
            set
            {
                if (textId != value)
                {
                    textId = value;
                    OnPropertyChanged("TextId");
                }
            }
        }

        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        public string Ime
        {
            get { return ime; }
            set
            {
                if (ime != value)
                {
                    ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }

        public Tip Tip
        {
            get { return tip; }
            set
            {
                if (tip != value)
                {

                    tip = value;
                    tip.Naziv = value.Naziv;
                    tip.Slika = value.Slika;
                    OnPropertyChanged("Tip");
                }
            }
        }

        public double Vrednost
        {
            get { return vrednost; }
            set
            {
                if (this.vrednost != value)
                {
                    this.vrednost = value;
                    OnPropertyChanged("Vrednost");
                }
            }
        }
        #endregion

        #region OSTALO
        public bool IsValueValidForType()
        {
            bool isValid = true;
            if (Vrednost > 350 || Vrednost < 250)
                isValid = false;

            return isValid;
        }

        public bool IsRTD()
        {
            if (tip.Naziv == "RTD")
                return true;
            return false;
        }

        protected override void ValidateSelf()
        {
            int tempId;
            bool parsingSuccess = int.TryParse(this.textId, out tempId);

            if (this.DoesIdAlreadyExist)
            {
                this.ValidationErrors["Id"] = "Id already exists.";
            }

            if (!parsingSuccess)
            {
                this.ValidationErrors["Id"] = "Id must be an integer.";
            }
            else if (tempId < 0)
            {
                this.ValidationErrors["Id"] = "Id can't be negative.";
            }

            if (string.IsNullOrWhiteSpace(this.textId))
            {
                this.ValidationErrors["Id"] = "Id is required.";
            }

            if (string.IsNullOrWhiteSpace(this.Ime))
            {
                this.ValidationErrors["Ime"] = "Name is required.";
            }
        }
        #endregion

        public Reaktor() { }
        
        public Reaktor(Reaktor s)
        {
            Id = s.Id;
            Ime = s.Ime;
            Tip = s.tip;
            Vrednost = s.Vrednost;
        }

        public override string ToString()
        {
            return $"{Id}. {Ime}";
        }
    }
}
