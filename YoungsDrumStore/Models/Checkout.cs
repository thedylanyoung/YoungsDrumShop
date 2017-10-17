using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace YoungsDrumStore.Models
{
    public class Checkout
    {
        [Required(ErrorMessage = "This is a required Field.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "This is a required Field.")]
        public string City { get; set; }
        [Required(ErrorMessage = "This is a required Field.")]
        public string State { get; set; }
        [Required(ErrorMessage = "This is a required Field.")]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "This is a required Field.")]
        public string CardNumber { get; set; }
        [Required(ErrorMessage = "This is a required Field.")]
        public string CardExpiration { get; set; }
        [Required(ErrorMessage = "This is a required Field.")]
        public string CCV { get; set; }
    }
}