using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoungsDrumStoreDAL.Models
{
    public class CymbalDO
    {
        public int CymbalID { get; set; }
        public int AccountID { get; set; }
        public string BrandName { get; set; }
        public decimal CymbalPrice { get; set; }
        public int CymbalQuantity { get; set; }
        public string CymbalName { get; set; }
        public string CymbalDescription { get; set; }
        public string CymbalImgURL { get; set; }
    }
}
