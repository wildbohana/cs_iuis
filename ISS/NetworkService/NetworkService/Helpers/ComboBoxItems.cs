using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkService.Helpers
{
    public class ComboBoxItems
    {
        public static Dictionary<string, string> entityTypes = new Dictionary<string, string>()
        {
            { "RTD", "pack://application:,,,/NetworkService;component/Assets/rtd.png" },
            { "Termosprega", "pack://application:,,,/NetworkService;component/Assets/sprega.png" }
        };
    }
}
