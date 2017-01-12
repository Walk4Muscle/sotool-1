using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace StackModel
{
    [DataContract(Namespace = "http://stackoverflow.com/")]
    public class Labors
    {
        [DataMember(Name = "question_id")]
        public int Question_id;
        [DataMember(Name = "alias")]
        public string Alias;
        [DataMember(Name = "UT")]
        public int UT;
        [DataMember(Name = "LogDate")]
        public string LogDate ;
        [DataMember(Name = "UTComments")]
        public string UTComments;
    }
}
