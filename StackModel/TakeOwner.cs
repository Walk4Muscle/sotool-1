using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace StackModel
{
    [DataContract(Namespace = "http://stackoverflow.com/")]
    public class TakeOwner
    {
        [DataMember(Name = "takeownerresult")]
        public bool TakeOwnerResult;
        [DataMember(Name = "errormessage")]
        public string ErrorMessage;
    }
}
