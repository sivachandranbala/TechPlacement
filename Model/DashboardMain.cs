using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechPlacement.Model
{
    public class DashboardMain
    {
        public string StudentId { get; set; }
        public string Name { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string EnrollNo { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string Education { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string PassYear { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string Department { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string CGPA { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string Skill { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string Address { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string PersonName { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string ContactEmail { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string MobileNo { get; set; }

    }
}