using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace StackModel
{
    [DataContract(Namespace = "http://stackoverflow.com/")]
    public class Tag
    {

        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "has_synonyms")]
        public bool Has_synonyms { get; set; }

    }




    public class TagParam : MyParam
    {
        public string Inname { get; set; }

        public TagParam() 
        {
            Order = "asc";
            Sort = "name";
        }

    }
}
