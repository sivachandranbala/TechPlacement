using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechPlacement.Model
{
    public class PlacementDetails
    {
        public string JobCategory { get; set; }
        public string Min_CGPA { get; set; }
        public string NumberOfPositions { get; set; }
        public string InterviewDate { get; set; }
        public string Status { get; set; }

    }
}