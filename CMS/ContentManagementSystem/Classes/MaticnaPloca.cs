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
        private bool brisanje;
        private int godinaProizvodnje;
        private string naziv;
        private string urlSlike;
        private string urlRtf;
        private DateTime datumDodavanja;

        // Propertiji
        public bool Brisanje { get => brisanje; set => brisanje = value; }
        public int GodinaProizvodnje { get => godinaProizvodnje; set => godinaProizvodnje = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public string UrlSlike { get => urlSlike; set => urlSlike = value; }
        public string UrlRtf { get => urlRtf; set => urlRtf = value; }
        public DateTime DatumDodavanja { get => datumDodavanja; set => datumDodavanja = value; }

        // Konstruktor
        public MaticnaPloca(int godinaProizvodnje, string naziv, string urlSlike, string urlRtf, DateTime datumDodavanja)
        {
            this.brisanje = false;
            this.godinaProizvodnje = godinaProizvodnje;
            this.naziv = naziv;
            this.urlSlike = urlSlike;
            this.urlRtf = urlRtf;
            this.datumDodavanja = datumDodavanja;
        }

        // Zbog serijalizacije, mora da postoji i konstruktor bez parametara
        public MaticnaPloca()
        {
            brisanje = false;
            godinaProizvodnje = 0;
            naziv = "";
            urlSlike = "";
            urlRtf = "";
            datumDodavanja = DateTime.MinValue;
        }
    }
}
