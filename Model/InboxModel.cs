using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechPlacement.Model
{
    public class InboxModel
    {
     
        public string Id { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string FromName { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string From { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string To { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string Message { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string Status { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string EntryDate { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string MessageType { get; set; }
        
        public List<string> Clist { get; set; }

    }
}