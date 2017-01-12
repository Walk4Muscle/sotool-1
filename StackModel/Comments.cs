using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace StackModel
{
    [DataContract(Namespace = "http://stackoverflow.com/")]
    public class Comments
    {
        [DataMember(Name = "comment_id")]
        public int Comment_id { get; set; }
        [DataMember(Name="post_id")]
        public int Post_id { get; set; }
        [DataMember(Name="creation_date")]
        public long Creation_date { get; set; }
        //[DataMember(Name="link")]
        //public string Link { get; set; }
        //[DataMember(Name="body")]
        //public string Body { get; set; }
        [DataMember(Name = "owner")]
        public User Owner;
        [DataMember(Name="post_type")]
        public string Post_type { get; set; }
        [DataMember(Name = "score")]
        public int Score { get; set; }
        [DataMember(Name = "edited")]
        public bool Edited { get; set; }
    }

    public class CommentParam : MyParam
    {

        public CommentParam()
        {
            Order = "desc";
            Sort = "creation";
        }

    }
}
