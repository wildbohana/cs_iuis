using System;
using System.Collections.Generic;
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
    }
}
