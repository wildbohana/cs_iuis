using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystem.Classes
{
    public class Spisak
    {
        private List<MaticnaPloca> spisakPloca = new List<MaticnaPloca>();
        public List<MaticnaPloca> SpisakPloca { get => spisakPloca; set => spisakPloca = value; }
    }
}
