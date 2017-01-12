using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace StackModel
{
    public class Scenario
    {
        [DataMember(Name = "id")]
        public int id;
        [DataMember(Name = "ScenarioName")]
        public string ScenarioName;
        [DataMember(Name = "Category")]
        public string Category;
        [DataMember(Name = "Tags")]
        public string Tags;
        [DataMember(Name = "Description")]
        public string Description;
    }
}
