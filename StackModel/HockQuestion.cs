using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StackModel
{
    public class HockQuestion
    {
        [DataMember(Name = "question_id")]
        public string Question_id;


        [DataMember(Name = "avg_response_time")]
        public string IRT;
        [DataMember(Name = "html_href")]
        public string Link;

        [DataMember(Name = "last_updated_at")]
        public long Last_edit_date;

        [DataMember(Name = "title")]
        public string Title;
        [DataMember(Name = "state")]
        public string status;
        [DataMember(Name = "created_at")]
        public string Create_date;

        [DataMember(Name = "tags")]
        public string[] Tags;

        [DataMember(Name = "author_email")]
        public User Owner;

        [DataMember(Name = "utdata")]
        public int UTData;


        [DataMember(Name = "comments")]
        public HockComments[] Comments;
        [DataMember(Name = "body")]
        public string Body;




        [DataMember(Name = "accepted_answer_id")]
        public int Accepted_answer_id;
        [DataMember(Name = "answer_count")]
        public int Answer_count;
        [DataMember(Name = "answers")]
        public [] Answers;

        [DataMember(Name = "bounty_amount")]
        public int Bounty_amount;
        [DataMember(Name = "bounty_closes_date")]
        public long Bounty_closes_date;
        [DataMember(Name = "closed_date")]
        public long Closed_date;
        [DataMember(Name = "closed_reason")]
        public string Closed_reason;

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


        [DataMember(Name = "locked_date")]
        public long Locked_date;
        [DataMember(Name = "migrated_from")]
        public Migration_info Migrated_from;
        [DataMember(Name = "Migrated_to")]
        public Migration_info Migrated_to;
        
        [DataMember(Name = "protected_date")]
        public long Protected_date;


        [DataMember(Name = "up_vote_count")]
        public int Up_vote_count;
        [DataMember(Name = "view_count")]
        public int View_count;

       
        [DataMember(Name = "support_alias")]
        public string Support_alias;

        [DataMember(Name = "active_date")]
        public string Active_date;


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

{"offset":0,
"per_page":30,
"total":14357,
"discussions":
[
    {"toggle_href":"https://api.tenderapp.com:443/hockeyapp/discussions/15805962/toggle",
    "last_user_id":3509857,
    "last_comment_id":39079252,
    "last_author_name":"Vlad Feier",
    "via":"web",
    
    "category_href":"https://api.tenderapp.com:443/hockeyapp/categories/38238",
    "user_href":"https://api.tenderapp.com:443/hockeyapp/users/3509857",
   
    "number":52064,
   
    "unqueue_href":"https://api.tenderapp.com:443/hockeyapp/discussions/15805962/unqueue?queue={queue_id}",
    "watchers_count":4,
    "last_author_email":"vlfei@microsoft.com",
    "public":false,
    "unresolve_href":"https://api.tenderapp.com:443/hockeyapp/discussions/15805962/unresolve",
    "unresponded":false,
    "redirection_id":null,
    "extras":{"browser":"Chrome 47.0.2526.111 (Windows NT 10.0)","external_url":"https://rink.hockeyapp.net/users/662947"}, 
    "comments_href":"https://api.tenderapp.com:443/hockeyapp/discussions/15805962/comments{?page}",
    "private_body":"<ul><li>Browser: Chrome 47.0.2526.111 (Windows NT 10.0)</li><li>External url: https://rink.hockeyapp.net/users/662947</li></ul>",
    "cached_queue_list":[24275],
    "activity_filter_stamp":null,
    "acknowledge_href":"https://api.tenderapp.com:443/hockeyapp/discussions/15805962/acknowledge",
    "updated_at":"2016-02-03T09:32:17Z",
    "suggested_faqs":["51099","50859","67410"],
    "hidden":false,
    "company_id":null,
    "resolve_href":"https://api.tenderapp.com:443/hockeyapp/discussions/15805962/resolve",
    "last_via":"web",
    "unacknowledge_href":"https://api.tenderapp.com:443/hockeyapp/discussions/15805962/unacknowledge",
    "author_email":"vlfei@microsoft.com",
    "author_name":"Vlad Feier",
    "spawned_from_comment_id":null,
    "permalink":"search-for-crash-within-specific-time-interval-returns-badrequest",
    "comments_count":6
    }


    {"category_href":"https://api.tenderapp.com:443/hockeyapp/categories/38238","user_href":"https://api.tenderapp.com:443/hockeyapp/users/3509857",
    "public":false,"unqueue_href":"https://api.tenderapp.com:443/hockeyapp/discussions/15805962/unqueue?queue={queue_id}",
    "watchers_count":4,"last_author_email":"vlfei@microsoft.com","spawned_from_comment_id":null,"redirection_id":null,"hidden":false,
    "activity_filter_stamp":null,"unresolve_href":"https://api.tenderapp.com:443/hockeyapp/discussions/15805962/unresolve",
    "unresponded":false,"private_body":"<ul><li>Browser: Chrome 47.0.2526.111 (Windows NT 10.0)</li><li>External url: https://rink.hockeyapp.net/users/662947</li></ul>",
    "last_updated_at":"2016-02-03T09:32:15Z","avg_response_time":1809,"html_href":"http://support.hockeyapp.net/discussions/problems/52064",
    "restore_href":"https://api.tenderapp.com:443/hockeyapp/discussions/15805962/restore",
    "comments_href":"https://api.tenderapp.com:443/hockeyapp/discussions/15805962/comments{?page}",
    "unread":true,"permalink":"search-for-crash-within-specific-time-interval-returns-badrequest",
    "last_via":"web","company_id":null,"acknowledge_href":"https://api.tenderapp.com:443/hockeyapp/discussions/15805962/acknowledge",
    "last_user_id":3509857,"last_comment_id":39079252,"resolve_href":"https://api.tenderapp.com:443/hockeyapp/discussions/15805962/resolve",
    "state":"open","unacknowledge_href":"https://api.tenderapp.com:443/hockeyapp/discussions/15805962/unacknowledge",
    "author_email":"vlfei@microsoft.com","author_name":"Vlad Feier","created_at":"2016-02-02T16:32:40Z","cached_queue_list":[24275],
    "toggle_href":"https://api.tenderapp.com:443/hockeyapp/discussions/15805962/toggle","updated_at":"2016-02-03T09:32:17Z",
    "title":"Search for crash within specific time interval returns BadRequest","suggested_faqs":["51099","50859","67410"],
    "extras":{"browser":"Chrome 47.0.2526.111 (Windows NT 10.0)","external_url":"https://rink.hockeyapp.net/users/662947"},
    "comments_count":6,"change_category_href":"https://api.tenderapp.com:443/hockeyapp/discussions/15805962/change_category?to={category_id}",
    "href":"https://api.tenderapp.com:443/hockeyapp/discussions/15805962","number":52064,
    "comments":
[
    {"user_href":"https://api.tenderapp.com:443/hockeyapp/users/3509857",
    "body":"I'm using Crash API to search for crashes within a specific hour of day. My uri is this:\r\n\r\nhttps://rink.hockeyapp.net/api/2/apps/<my_app_id_here>/crashes/search?query=created_at:[\"2016-02-02T15:00\" TO \"2016-02-02T15:59\"]\r\n\r\nThe auth token is set ok, since other request return correctly. I'm using the HttpClient from C#/.Net. In the crashes page of HockeyApp website, I can use this query and the crashes are returned.\r\nWhat is wrong in the URL? I tried encoding it, same result, I tried removing the spaces around \"TO\", same result.",
    "user_is_supporter":false,
    "resolution":null,
    "internal":false,
    "user_ip":"167.220.196.185",
    "referrer":"http://support.hockeyapp.net/discussions/problems",
    "html_href":"http://support.hockeyapp.net/discussions/problems/52064",
    "author_email":"vlfei@microsoft.com",
    "author_name":"Vlad Feier",
    "created_at":"2016-02-02T16:32:40Z",
    "system_message":false,
    "user_agent":"Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.111 Safari/537.36",
    "number":1,
    "assets":[],
    "via":"web",
    "formatted_body":"<div><p>I'm using Crash API to search for crashes within a specific hour\nof day. My uri is this:</p>\n<p><a href=\"https://rink.hockeyapp.net/api/2/apps/\">https://rink.hockeyapp.net/api/2/apps/</a>/crashes/search?query=created_at:[\"2016-02-02T15:00\"\nTO \"2016-02-02T15:59\"]</p>\n<p>The auth token is set ok, since other request return correctly.\nI'm using the HttpClient from C#/.Net. In the crashes page of\nHockeyApp website, I can use this query and the crashes are\nreturned.<br>\nWhat is wrong in the URL? I tried encoding it, same result, I tried\nremoving the spaces around \"TO\", same result.</p></div>"}
    ,{
    "user_href":"https://api.tenderapp.com:443/hockeyapp/users/3387725",
    "body":"Discussion was assigned to Shawn Dyas",
    "user_is_supporter":true,
    "resolution":null,
    "internal":true,
    "user_ip":null,
    "referrer":null,
    "html_href":"http://support.hockeyapp.net/discussions/problems/52064",
    "author_email":"v-shdyas@microsoft.com",
    "author_name":"Shawn Dyas",
    "created_at":"2016-02-02T16:52:21Z",
    "system_message":true,
    "user_agent":null,
    "number":2,
    "assets":[],
    "via":"web",
    "formatted_body":"<div><p>Discussion was assigned to Shawn Dyas</p></div>"
    },{
    "user_href":"https://api.tenderapp.com:443/hockeyapp/users/858067",
    "body":"@Shawn: He needs to URL-encode the query string. If this doesn't work, he should provide his encoded string.",
    "user_is_supporter":true,
    "resolution":null,
    "internal":true,
    "user_ip":"131.107.160.183",
    "referrer":"http://support.hockeyapp.net/discussions/problems/52064-search-for-crash-within-specific-time-interval-returns-badrequest",
    "html_href":"http://support.hockeyapp.net/discussions/problems/52064",
    "author_email":"thdohmke@microsoft.com",
    "author_name":"Thomas Dohmke",
    "created_at":"2016-02-02T16:55:41Z",
    "user_agent":"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11_3) AppleWebKit/601.4.4 (KHTML, like Gecko) Version/9.0.3 Safari/601.4.4",
    "number":3,
    "assets":[],
    "via":"web",
    "formatted_body":"<div><p>@Shawn: He needs to URL-encode the query string. If this doesn't\nwork, he should provide his encoded string.</p></div>"
    },
    {"user_href":"https://api.tenderapp.com:443/hockeyapp/users/3387725","body":"Hi Vlad,\r\n\r\nYou'll need to url-encode the query string, if you can reproduce the issue after url-encoding then please provide us with the string.\r\n\r\nThanks,\r\nShawn","user_is_supporter":true,"resolution":null,"internal":false,
    "user_ip":"216.243.61.220","referrer":"http://support.hockeyapp.net/discussions/problems/52064-search-for-crash-within-specific-time-interval-returns-badrequest","html_href":"http://support.hockeyapp.net/discussions/problems/52064",
    "author_email":"v-shdyas@microsoft.com","author_name":"Shawn Dyas","created_at":"2016-02-02T17:02:49Z","system_message":false,"user_agent":"Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.97 Safari/537.36","number":4,"assets":[],"via":"web","formatted_body":"<div><p>Hi Vlad,</p>\n<p>You'll need to url-encode the query string, if you can reproduce\nthe issue after url-encoding then please provide us with the\nstring.</p>\n<p>Thanks,<br>\nShawn</p></div>"},{"user_href":"https://api.tenderapp.com:443/hockeyapp/users/3509857",
    "body":"Hi Shawn,\r\nThanks for the quick hint. The encoded query returns the same error:\r\nhttps://rink.hockeyapp.net/api/2/apps/APP_ID/crashes/search?query=created_at%3A%5B%222016-02-02T15%3A00%22+TO+%222016-02-02T15%3A59%22%5D\r\n\r\nDo you need the APP_ID also?\r\n\r\nVlad","user_is_supporter":false,"resolution":null,"internal":false,"user_ip":"167.220.196.185",
    "referrer":"http://support.hockeyapp.net/discussions/problems/52064-search-for-crash-within-specific-time-interval-returns-badrequest","html_href":"http://support.hockeyapp.net/discussions/problems/52064","author_email":"vlfei@microsoft.com","author_name":"Vlad Feier","created_at":"2016-02-02T17:06:48Z","system_message":false,"user_agent":"Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.111 Safari/537.36","number":5,"assets":[],"via":"web",
    "formatted_body":"<div><p>Hi Shawn,<br>\nThanks for the quick hint. The encoded query returns the same\nerror:<br>\n<a href=\"https://rink.hockeyapp.net/api/2/apps/APP_ID/crashes/search?query=created_at%3A%5B%222016-02-02T15%3A00%22+TO+%222016-02-02T15%3A59%22%5D\">\nhttps://rink.hockeyapp.net/api/2/apps/APP_ID/crashes/search?query=c...</a></p>\n<p>Do you need the APP_ID also?</p>\n<p>Vlad</p></div>"},{"user_href":"https://api.tenderapp.com:443/hockeyapp/users/3387725","body":"The discussion is now private.","user_is_supporter":true,
    "resolution":null,"internal":true,"user_ip":null,"referrer":null,"html_href":"http://support.hockeyapp.net/discussions/problems/52064","author_email":"v-shdyas@microsoft.com","author_name":"Shawn Dyas","created_at":"2016-02-02T17:54:35Z","system_message":true,"user_agent":null,"number":6,"assets":[],"via":"web","formatted_body":"<div><p>The discussion is now private.</p></div>"},{"user_href":"https://api.tenderapp.com:443/hockeyapp/users/3387725","body":"Discussion is no longer assigned to Shawn Dyas","user_is_supporter":true,"resolution":null,"internal":true,"user_ip":null,"referrer":null,"html_href":"http://support.hockeyapp.net/discussions/problems/52064","author_email":"v-shdyas@microsoft.com","author_name":"Shawn Dyas","created_at":"2016-02-02T18:04:12Z",
    "system_message":true,"user_agent":null,"number":7,"assets":[],"via":"web","formatted_body":"<div><p>Discussion is no longer assigned to Shawn Dyas</p></div>"},
    {"user_href":"https://api.tenderapp.com:443/hockeyapp/users/3387725","body":"Discussion was assigned to Thomas Dohmke","user_is_supporter":true,"resolution":null,"internal":true,"user_ip":null,"referrer":null,"html_href":"http://support.hockeyapp.net/discussions/problems/52064","author_email":"v-shdyas@microsoft.com","author_name":"Shawn Dyas","created_at":"2016-02-02T18:04:15Z","system_message":true,"user_agent":null,"number":8,"assets":[],"via":"web","formatted_body":"<div><p>Discussion was assigned to Thomas Dohmke</p></div>"},{"user_href":"https://api.tenderapp.com:443/hockeyapp/users/3387725","body":"Hi Vlad,\r\n\r\nScript looks fine, I double checked by actually running it against my own app. Can you check if the namespace in your App.xaml.cs file matches the corresponding namespace on HockeyApp ID? Please verify your namespace by clicking on your app then \"Manage App > Basic Data\".\r\n\r\nThanks,\r\nShawn","user_is_supporter":true,"resolution":null,"internal":false,"user_ip":"216.243.61.220","referrer":"http://support.hockeyapp.net/discussions/problems/52064-search-for-crash-within-specific-time-interval-returns-badrequest","html_href":"http://support.hockeyapp.net/discussions/problems/52064","author_email":"v-shdyas@microsoft.com","author_name":"Shawn Dyas","created_at":"2016-02-02T21:20:56Z","system_message":false,"user_agent":"Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.97 Safari/537.36","number":9,"assets":[],"via":"web","formatted_body":"<div><p>Hi Vlad,</p>\n<p>Script looks fine, I double checked by actually running it\nagainst my own app. Can you check if the namespace in your\nApp.xaml.cs file matches the corresponding namespace on HockeyApp\nID? Please verify your namespace by clicking on your app then\n\"Manage App &gt; Basic Data\".</p>\n<p>Thanks,<br>\nShawn</p></div>"},{"user_href":"https://api.tenderapp.com:443/hockeyapp/users/3387725","body":"HI Vlad,\r\n\r\nSorry I was thinking you were trying to upload crashes, you are just trying search via api. That script works fine which app id is this? \r\n\r\nThanks,\r\nShawn","user_is_supporter":true,"resolution":null,"internal":false,"user_ip":"216.243.61.220","referrer":"http://support.hockeyapp.net/discussions/problems/52064-search-for-crash-within-specific-time-interval-returns-badrequest","html_href":"http://support.hockeyapp.net/discussions/problems/52064","author_email":"v-shdyas@microsoft.com","author_name":"Shawn Dyas","created_at":"2016-02-02T21:23:11Z","system_message":false,"user_agent":"Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.97 Safari/537.36","number":10,"assets":[],"via":"web","formatted_body":"<div><p>HI Vlad,</p>\n<p>Sorry I was thinking you were trying to upload crashes, you are\njust trying search via api. That script works fine which app id is\nthis?</p>\n<p>Thanks,<br>\nShawn</p></div>"},{"user_href":"https://api.tenderapp.com:443/hockeyapp/users/3509857","body":"Hi Shawn,\r\nI can see it works with some app ids, but doesn't work with other. One that doesn't work is 5916939b94264f9ea6b95f82ba199a09.\r\n\r\nThanks,\r\nVlad","user_is_supporter":false,"resolution":null,"internal":false,"user_ip":"167.220.196.184","referrer":"http://support.hockeyapp.net/discussions/problems/52064-search-for-crash-within-specific-time-interval-returns-badrequest","html_href":"http://support.hockeyapp.net/discussions/problems/52064","author_email":"vlfei@microsoft.com","author_name":"Vlad Feier","created_at":"2016-02-03T09:32:15Z","system_message":false,"user_agent":"Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.111 Safari/537.36","number":11,"assets":[],"via":"web","formatted_body":"<div><p>Hi Shawn,<br>\nI can see it works with some app ids, but doesn't work with other.\nOne that doesn't work is 5916939b94264f9ea6b95f82ba199a09.</p>\n<p>Thanks,<br>\nVlad</p></div>"}],"cached_queue_list":[24275],
    "via":"web","queue_href":"https://api.tenderapp.com:443/hockeyapp/discussions/15805962/queue?queue={queue_id}","last_author_name":"Vlad Feier"}