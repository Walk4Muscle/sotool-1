using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace StackModel
{
    [DataContract(Namespace = "http://stackoverflow.com/")]
    public class Question
    {
        [DataMember(Name = "accepted_answer_id")]
        public int Accepted_answer_id;
        [DataMember(Name = "answer_count")]
        public int Answer_count;
        [DataMember(Name = "answers")]
        public Answer[] Answers;
        [DataMember(Name = "body")]
        public string Body;
        [DataMember(Name = "bounty_amount")]
        public int Bounty_amount;
        [DataMember(Name = "bounty_closes_date")]
        public long Bounty_closes_date;
        [DataMember(Name = "closed_date")]
        public long Closed_date;
        [DataMember(Name = "closed_reason")]
        public string Closed_reason;
        [DataMember(Name = "comments")]
        public Comments[] Comments;
        [DataMember(Name = "community_owned_date")]
        public long Community_owned_date;
        [DataMember(Name = "creation_date")]
        public long Creation_date;
        [DataMember(Name = "down_vote_count")]
        public int Down_vote_count;
        [DataMember(Name = "favorite_count")]
        public int Favorite_count;
        [DataMember(Name = "is_answered")]
        public bool Is_answered;
        [DataMember(Name = "last_activity_date")]
        public long Last_activity_date;
        [DataMember(Name = "last_edit_date")]
        public long Last_edit_date;
        [DataMember(Name = "link")]
        public string Link;
        [DataMember(Name = "locked_date")]
        public long Locked_date;
        [DataMember(Name = "migrated_from")]
        public Migration_info Migrated_from;
        [DataMember(Name = "Migrated_to")]
        public Migration_info Migrated_to;
        [DataMember(Name = "owner")]
        public User Owner;
        [DataMember(Name = "protected_date")]
        public long Protected_date;
        [DataMember(Name = "question_id")]
        public int Question_id;
        [DataMember(Name = "score")]
        public int Score;
        [DataMember(Name = "tags")]
        public string[] Tags;
        [DataMember(Name = "title")]
        public string Title;
        [DataMember(Name = "up_vote_count")]
        public int Up_vote_count;
        [DataMember(Name = "view_count")]
        public int View_count;
        [DataMember(Name = "status")]
        public string status;
        [DataMember(Name = "IRT")]
        public string IRT;
        [DataMember(Name = "support_alias")]
        public string Support_alias;
        [DataMember(Name = "create_date")]
        public string Create_date;
        [DataMember(Name = "active_date")]
        public string Active_date;
        [DataMember(Name = "utdata")]
        public int UTData;

    }
    [DataContract(Namespace = "http://stackoverflow.com/")]
    public class MyAnswer
    {
        [DataMember(Name = "answer_id")]
        public int Answer_id { get; set; }
    }

    [DataContract(Namespace = "http://stackoverflow.com/")]
    public class Migration_info
    {
        [DataMember(Name = "other_site")]
       public Site Other_site { get; set; }
    }

    public class QuestionParam : MyParam
    {
        public string Tagged { get; set; }

        public QuestionParam()
        {
            Order = "desc";
            Sort = "activity";
        }
    }



}
