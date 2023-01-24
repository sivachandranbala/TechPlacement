using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechPlacement.Model
{
   
        public class CandidateResults
        {
        public int RID { get; set; }
        public int SId { get; set; }
        public int CId { get; set; }
         public string Name { get; set; }
        public string CName { get; set; }
        public string RoundName { get; set; }
        public int RoundResult { get; set; }
        public string OfferLetter { get; set; }
        public string RoundText { get; set; }
        public string Status { get; set; }
    }
    
}