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
        private string nazivTipa;
        private string slikaTipa;

        public string NazivTipa
        {
            get { return nazivTipa; }
            set
            {
                if (nazivTipa != value)
                {
                    nazivTipa = value;
                    OnPropertyChanged("NazivTipa");
                }
            }
        }

        public string SlikaTipa
        {
            get { return slikaTipa; }
            set
            {
                if (slikaTipa != value)
                {
                    slikaTipa = value;
                    OnPropertyChanged("SlikaTipa");
                }
            }
        }

        protected override void ValidateSelf()
        {
            if (this.NazivTipa == null)
            {
                this.ValidationErrors["NazivTipa"] = "Type must be selected.";
            }
        }
    }
}
