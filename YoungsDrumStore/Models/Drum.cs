using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace YoungsDrumStore.Models
{
    public class DrumPO
    {
        public int DrumID { get; set; }
        public int AccountID { get; set; }
        
        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }
        
        [Display(Name = "Drum Type")]
        public string DrumType { get; set; }
        [Display(Name = "Description")]
        public string DrumDescription { get; set; }
        
        [Display(Name = "Quantity")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Invalid Quantity")]
        public int DrumQuantity { get; set; }
        
        [Display(Name = "Drum Price")]
        [RegularExpression("^\\d{0,8}(\\.\\d{1,4})?$", ErrorMessage = "Invalid Price")]
        public decimal DrumPrice { get; set; }
        [Display(Name = "Image URL")]
        public string DrumImgURL { get; set; }
        [RegularExpression(@"^\d+$", ErrorMessage ="Invalid Quantity")]
        public int CheckoutQty { get; set; }
    }
}
