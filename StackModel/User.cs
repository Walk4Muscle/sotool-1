using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace StackModel
{
    [DataContract(Namespace = "http://stackoverflow.com/")]
    public class User
    {

        [DataMember(Name = "age")]
        public int Age { get; set; }
        [DataMember(Name = "badge_counts")]
        public Badge_counts Badge_counts { get; set; }
        [DataMember(Name = "creation_date")]
        public long Creation_date { get; set; }
        [DataMember(Name = "display_name")]
        public string Display_name { get; set; }
        [DataMember(Name = "last_modified_date")]
        public long Last_modified_date { get; set; }
        [DataMember(Name = "link")]
        public string Link { get; set; }
        [DataMember(Name = "location")]
        public string Location { get; set; }
        [DataMember(Name = "profile_image")]
        public string Profile_image { get; set; }
        [DataMember(Name = "reputation")]
        public int Reputation { get; set; }
        [DataMember(Name = "user_id")]
        public int User_id { get; set; }
        [DataMember(Name = "website_url")]
        public string Website_url { get; set; }
        [DataMember(Name = "user_type")]
        public string User_Type { get; set; }

    }
    [DataContract(Namespace = "http://stackoverflow.com/")]
    public class Badge_counts
    {
        [DataMember(Name = "gold")]
        public int Gold { get; set; }
        [DataMember(Name = "silver")]
        public int Silver { get; set; }
        [DataMember(Name = "bronze")]
        public int Bronze { get; set; }
    }


    public class UserParam : MyParam 
    {
      
            public string Inname { get; set; }

            public UserParam()
            {
                Order = "desc";
                Sort = "creation";
            }
        
    }



}
