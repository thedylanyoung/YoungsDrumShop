using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace YoungsDrumStore.Models
{
    public class ProductModel
    {
        public DrumPO aDrum { get; set; }
        public List<DrumPO> drumList { get; set; }
        public CymbalPO aCymbal { get; set; }
        public List<CymbalPO> cymbalList { get; set; }
        public decimal CartTotal { get; set; }

        

        public ProductModel()
        {
            aDrum = new DrumPO();
            drumList = new List<DrumPO>();
            aCymbal = new CymbalPO();
            cymbalList = new List<CymbalPO>();
        }
    }
}