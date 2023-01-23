using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechPlacement.Model
{
    public class Functions
    {
        public int FunctionId { get; set; }
        public string FunctionName { get; set; }
        public string FunctionType { get; set; }
        public int FunctionTypeId { get; set; }
        public string FunctionLink { get; set; }
        public int ParentFunctionId { get; set; }
    }
}