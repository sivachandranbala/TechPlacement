using System;
using System.ComponentModel.DataAnnotations;

namespace TechPlacement.Model
{
    public class CollegeMasterModel
    {
        [Required(ErrorMessage = "College Name is Required", AllowEmptyStrings = false)]
        [Display(Name = "CollegeName")]
        public string ClName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
        public string ContactPerson { get; set; }
        public string MobileNo { get; set; }
        public string ContactNo { get; set; }
        public string ClEmailId { get; set; }
        public string ContactEmailId { get; set; }
        public string Website { get; set; }
        [Required(ErrorMessage = "Username is Required", AllowEmptyStrings = false)]
        [Display(Name = "Username")]
        public string UName { get; set; }
        [Required(ErrorMessage = "Password is Required", AllowEmptyStrings = false)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
