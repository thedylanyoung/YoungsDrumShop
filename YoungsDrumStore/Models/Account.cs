using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace YoungsDrumStore.Models
{
    public class AccountPO
    {
        public int RoleID { get; set; }
        public int AccountID { get; set; }

        [Required(ErrorMessage = "This is a required Field.")]
        [Display(Name = "User Name")]
        [RegularExpression("^^[a-zA-Z0-9]([._](?![._])|[a-zA-Z0-9]){6,18}[a-zA-Z0-9]$", ErrorMessage = "Please use letters, numbers, or an underscore for User Name.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "This is a required field.")]
        [Display(Name = "Password")]
        [RegularExpression("(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,15})$", ErrorMessage = "Password must be 8-15 characters and include an Uppercase Letter and a number.")]
        public string PassWord { get; set; }
        
        [Display(Name = "First Name")]
        [RegularExpression("^[a-zA-Z''-'\\s]{1,40}$", ErrorMessage = "Please use letters for First Name.")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last Name")]
        [RegularExpression("^[a-zA-Z''-'\\s]{1,40}$", ErrorMessage = "Please use letters for Last Name.")]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
    }
}