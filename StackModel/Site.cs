using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace StackModel
{
    [DataContract(Namespace = "http://stackoverflow.com/")]
    public class Site
    {
        [DataMember(Name = "site_url")]
        public string Site_url { get; set; }

    }
}
