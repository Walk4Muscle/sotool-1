using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace StackModel
{
    [DataContract(Namespace = "http://stackoverflow.com/")]
    public class QualityReview
    {
        [DataMember(Name = "QR_id")]
        public string QR_id { get; set; }
        [DataMember(Name = "question_id")]
        public int question_id { get; set; }
        [DataMember(Name = "points")]
        public int points { get; set; }
        [DataMember(Name = "comment")]
        public string comment { get; set; }
        [DataMember(Name = "create_time")]
        public string createtime { get; set; }
        [DataMember(Name = "create_by")]
        public string create_by { get; set; }
        [DataMember(Name = "isfixed")]
        public string isfixed { get; set; }
        [DataMember(Name = "alias")]
        public string alias { get; set; }
        [DataMember(Name = "isnotified")]
        public string isnotified { get; set; }
        [DataMember(Name = "status")]
        public string status { get; set; }
    }
}
