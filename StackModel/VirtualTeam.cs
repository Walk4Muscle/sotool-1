using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace StackModel
{
    [DataContract(Namespace = "http://stackoverflow.com/")]
    public class VirtualTeam
    {
        [DataMember(Name = "question_id")]
        public string question_id { get; set; }
        [DataMember(Name = "team_name")]
        public string team_name { get; set; }
    }
}
