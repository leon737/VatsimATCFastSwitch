using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VatsimConnector.Models
{
    public class VatsimData
    {
        public ICollection<VatsimController> Controllers { get; set; }

        public ICollection<VatsimController> Atis { get; set; }
    }
}
