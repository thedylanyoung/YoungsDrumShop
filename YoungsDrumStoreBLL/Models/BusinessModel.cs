using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoungsDrumStoreBLL.Models;

namespace YoungsDrumStoreBLL.Models
{
    public class BusinessModel
    {
        public DrumBO aDrum { get; set; }
        public List<DrumBO> drumList { get; set; }
        public CymbalBO aCymbal { get; set; }
        public List<CymbalBO> cymbalList { get; set; }
        public decimal CartTotal { get; set; }

        public BusinessModel()
        {
            aDrum = new DrumBO();
            drumList = new List<DrumBO>();
            aCymbal = new CymbalBO();
            cymbalList = new List<CymbalBO>();
        }

    }
}
