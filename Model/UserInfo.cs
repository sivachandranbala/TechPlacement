using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechPlacement.Model
{
    public class UserInfo
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "Username is Required", AllowEmptyStrings = false)]
        [Display(Name = "Username")]

        public string UName { get; set; }
       
        [Required(ErrorMessage = "Password is Required", AllowEmptyStrings = false)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Type is Required", AllowEmptyStrings = false)]
        public string Type { get; set; }
    
    }
}