using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystem
{
    public class MaticnaPloca
    {
        // Polja
        private int id;
        private string naziv;
        private string urlSlike;
        private string urlRtf;
        private DateTime datumDodavanja;

        // Propertiji
        public int Id { get => id; set => id = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public string UrlSlike { get => urlSlike; set => urlSlike = value; }
        public string UrlRtf { get => urlRtf; set => urlRtf = value; }
        public DateTime DatumDodavanja { get => datumDodavanja; set => datumDodavanja = value; }

        // Konstruktor
        public MaticnaPloca(string naziv, string urlSlike, string urlRtf, DateTime datumDodavanja)
        {
            this.id = ++App.IdProizvoda;
            this.naziv = naziv;
            this.urlSlike = urlSlike;
            this.urlRtf = urlRtf;
            this.datumDodavanja = datumDodavanja;
        }

        // Zbog serijalizacije, mora da postoji i konstruktor bez parametara
        public MaticnaPloca()
        {
            id = 0;
            naziv = "";
            urlSlike = "";
            urlRtf = "";
            datumDodavanja = DateTime.MinValue;
        }

        //Dodati opciju da je podrazumevana vrednost za datum dodavanja ova ispod? 
        //DateTime defaultDT = new DateTime(2012, 6, 6, 12, 0, 0);
    }
}
