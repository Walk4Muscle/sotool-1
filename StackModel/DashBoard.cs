using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace StackModel
{
    public class DashBoard
    {
        [DataMember(Name = "fromdate")]
        public string fromdate;
        [DataMember(Name = "todate")]
        public string todate;
        [DataMember(Name = "alias")]
        public string alias;
    }

    public class DashBoardData
    {
        [DataMember(Name = "total")]
        public int Total;
        [DataMember(Name = "personal")]
        public int Personal;
    }
}
