using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace YoungsDrumStore.Models
{
    public class CymbalPO
    {
        public int CymbalID { get; set; }
        public int AccountID { get; set; }
        
        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }
       
        [Display(Name = "Cymbal Price")]
        [RegularExpression("^\\d{0,8}(\\.\\d{1,4})?$", ErrorMessage = "Invalid Price")]
        public decimal CymbalPrice { get; set; }
        
        [Display(Name = "Quantity")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Invalid Quantity")]
        public int CymbalQuantity { get; set; }
        
        [Display(Name = "Cymbal Name")]
        public string CymbalName { get; set; }
        [Display(Name = "Description")]
        public string CymbalDescription { get; set; }
        [Display(Name = "Image URL")]
        public string CymbalImgURL { get; set; }
        public int CheckoutQty { get; set; }
    }
}