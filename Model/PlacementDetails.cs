using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechPlacement.Model
{
    public class PlacementDetails
    {
        //public string LastDate { get; set; }
        //public string JobCategory { get; set; }
        //public string RequiredSkill { get; set; }
        //public string Role { get; set; }
        //public string Min_Qualification { get; set; }
        //public string Extra_Skill { get; set; }
        //public string MaxAge { get; set; }
        //public string ExpectedSalary { get; set; }
        //public string JobLocation { get; set; }

        public int PId { get; set; }
        public int ClId { get; set; }
        public int CId { get; set; }
        public string JobCategory { get; set; }
        public string Min_CGPA { get; set; }
        public int NumberOfPositions { get; set; }
        public DateTime InterviewDate { get; set; }
        public string Status { get; set; }       

    }
}