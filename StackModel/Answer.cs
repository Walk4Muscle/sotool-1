using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace StackModel
{
    [DataContract(Namespace = "http://stackoverflow.com/")]
    public class Answer
    {
        [DataMember(Name = "answer_id")]
        public int Answer_id { get; set; }
        [DataMember(Name = "body")]
        public string Body { get; set; }
        [DataMember(Name = "comments")]
        public MyComment[] Comments { get; set; }
        [DataMember(Name = "community_owned_date")]
        public long Community_owned_date { get; set; }
        [DataMember(Name = "creation_date")]
        public long Creation_date { get; set; }
        [DataMember(Name = "down_vote_count")]
        public int Down_vote_count { get; set; }
        [DataMember(Name = "is_accepted")]
        public bool Is_accepted { get; set; }
        [DataMember(Name = "last_activity_date")]
        public long Last_activity_date { get; set; }
        [DataMember(Name = "last_edit_date")]
        public long Last_edit_date { get; set; }
        [DataMember(Name = "link")]
        public string Link { get; set; }
        [DataMember(Name = "locked_date")]
        public long Locked_date { get; set; }
        [DataMember(Name = "owner")]
        public User Owner { get; set; }
        [DataMember(Name = "question_id")]
        public int Question_id { get; set; }
        [DataMember(Name = "score")]
        public int Score { get; set; }
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "up_vote_count")]
        public int Up_vote_count { get; set; }

    }
    [DataContract(Namespace = "http://stackoverflow.com/")]
    public class MyComment
    {
        [DataMember(Name = "comment_id")]
        public int Comment_id { get; set; }
    }
    [DataContract(Namespace = "http://stackoverflow.com/")]
    public class Owner
    {
        [DataMember(Name = "user_id")]
        public int User_id { get; set; }
    }

    public class AnswerParam : MyParam
    {


        public AnswerParam()
        {
            Order = "desc";
            Sort = "creation";
        }

    }
}
