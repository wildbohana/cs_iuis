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
                    tip.NazivTipa = value.NazivTipa;
                    tip.NazivTipa = value.NazivTipa;
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

        #region ISPIS
        public override string ToString()
        {
            return $"{Id}. {Ime}";
        }
        #endregion

        #region VALIDACIJA
        protected override void ValidateSelf()
        {
            int parsedId;
            bool canParse = int.TryParse(this.textId, out parsedId);

            if (!canParse)
            {
                this.ValidationErrors["Id"] = "Id must be an number.";
            }
            else if (parsedId < 0)
            {
                this.ValidationErrors["Id"] = "Id must be a positive number.";
            }
            if (this.IdExists)
            {
                this.ValidationErrors["Id"] = "Id already exists.";
            }
            if (string.IsNullOrEmpty(this.textId))
            {
                this.ValidationErrors["Id"] = "Id is requiered.";
            }
            if (string.IsNullOrEmpty(this.Ime))
            {
                this.ValidationErrors["Name"] = "Name is requiered.";
            }
        }
        #endregion
    }
}
