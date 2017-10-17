using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoungsDrumStoreDAL.Models
{
    public class DrumDO
    {
        public int DrumID { get; set; }
        public int AccountID { get; set; }
        public string BrandName { get; set; }
        public string DrumType { get; set; }
        public string DrumDescription { get; set; }
        public int DrumQuantity { get; set; }
        public decimal DrumPrice { get; set; }
        public string DrumImgURL { get; set; }
    }
}
