using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace StackModel
{
    [DataContract(Namespace = "http://stackoverflow.com/")]
    public class QualityReview_eng
    {
        [DataMember(Name = "QR_eng_id")]
        public string QR_eng_id { get; set; }
        [DataMember(Name = "question_id")]
        public string question_id { get; set; }
        [DataMember(Name = "QR_id")]
        public string QR_id { get; set; }
        [DataMember(Name = "alias")]
        public string alias { get; set; }
        [DataMember(Name = "create_time")]
        public string create_time { get; set; }
        [DataMember(Name = "eng_comment")]
        public string eng_comment { get; set; }
        [DataMember(Name = "action")]
        public string action { get; set; }
    }
}
