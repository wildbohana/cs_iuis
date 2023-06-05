using NetworkService.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NetworkService.Models
{
    public class Tip : ValidationBase   
    {
        private string naziv;
        private string slika = "Assets/empty.png";

        public string Naziv
        {
            get { return naziv; }
            set
            {
                if (naziv != value)
                {
                    naziv = value;
                    Slika = Helpers.ComboBoxItems.entityTypes[value];
                    OnPropertyChanged("Naziv");      // TODO Name ili Naziv?
                }
            }
        }

        public string Slika
        {
            get { return slika; }
            set
            {
                if (slika != value)
                {
                    slika = value;
                    OnPropertyChanged("Slika");      // TODO ImgSrc ili Slika?
                }
            }
        }

        public Tip() { }

        public Tip(Tip t)
        {
            Naziv = t.naziv;
            Slika = t.slika;
        }

        protected override void ValidateSelf()
        {
            if (this.Naziv == null)
            {
                this.ValidationErrors["Naziv"] = "Type must be selected.";
            }
        }
    }
}
