using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackModel
{
   public class MyParam
    {
        public int? Page { get; set; }
        public int? Pagesize { get; set; }
        public DateTime? Fromdate { get; set; }
        public DateTime? Todate { get; set; }
        public DateTime? Max { get; set; }
        public DateTime? Min { get; set; }
        public string Order { get; set; }
        public string Sort { get; set; }
        //public string Tagged { get; set; }
    }
}
