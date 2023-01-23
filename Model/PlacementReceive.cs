using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechPlacement.Model
{
    public class PlacementReceive
    {
        public string LastDate { get; set; }
        public string JobCategory { get; set; }
        public string RequiredSkill { get; set; }
        public string Role { get; set; }
        public string Min_Qualification { get; set; }
        public string Extra_Skill { get; set; }
        public string MaxAge { get; set; }
        public string ExpectedSalary { get; set; }
        public string JobLocation { get; set; }

    }
}