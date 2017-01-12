using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace StackModel
{
    [DataContract(Namespace = "http://stackoverflow.com/")]
   public class SupportTeam
    {
        [DataMember(Name = "Team_id")]
        public string questiTeam_id { get; set; }
        [DataMember(Name = "Team_name")]
        public string Team_name { get; set; }
    }
}
