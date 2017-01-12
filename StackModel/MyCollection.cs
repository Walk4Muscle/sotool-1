using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace StackModel
{
    [DataContract(Namespace = "http://stackoverflow.com/")]
    public class MyCollection<T>
    {
        [DataMember(Name = "total")]
        public int Total { get; set; }
        [DataMember(Name = "page_size")]
        public int Page_size { get; set; }
        [DataMember(Name = "page")]
        public int Page { get; set; }
        [DataMember(Name = "items")]
        public List<T> Items { get; set; }
    }
}
