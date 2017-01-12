using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace StackModel
{
   public class SupportEngineer
    {
        [DataMember(Name = "id")]
        public int id;
        [DataMember(Name = "DisplayName")]
        public string DisplayName;
        [DataMember(Name = "Alias")]
        public string Alias;
        [DataMember(Name = "StackoverflowID")]
        public string StackoverflowID;
    }
}
