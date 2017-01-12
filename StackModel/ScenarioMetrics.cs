using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace StackModel
{
    [DataContract]
    public class ScenarioMetrics
    {
        [DataMember(Name = "Month")]
        public int Month { get; set; }
        [DataMember(Name = "MonthName")]
        public string MonthName { get; set; }
        [DataMember(Name = "Year")]
        public int Year { get; set; }
        [DataMember(Name = "Scenario")]
        public string Scenario { get; set; }
        [DataMember(Name = "Volume")]
        public int Volume { get; set; }
        [DataMember(Name = "ReplyWithoutComVolume")]
        public int ReplyWithoutComVolume { get; set; }
        [DataMember(Name = "RR1Day")]
        public double RR1Day { get; set; }

        [DataMember(Name = "RR3Day")]
        public double RR3Day { get; set; }
        [DataMember(Name = "OverallRR")]
        public double OverallRR { get; set; }
        [DataMember(Name = "AR3Day")]
        public double AR3Day { get; set; }
        [DataMember(Name = "AR7Day")]
        public double AR7Day { get; set; }
        [DataMember(Name = "OverallAR")]
        public double OverallAR { get; set; }
        [DataMember(Name = "AveragetIRT")]
        public double AveragetIRT { get; set; }

        [DataMember(Name = "NOIR")]
        public double NOIR { get; set; }

        [DataMember(Name = "HR7Day")]
        public double HR7Day { get; set; }

        [DataMember(Name = "HR3Day")]
        public double HR3Day { get; set; }

        [DataMember(Name = "AHR3Day")]
        public double AHR3Day { get; set; }
        [DataMember(Name = "OverallHR")]
        public double OverallHR { get; set; }
        [DataMember(Name = "AHR7Day")]
        public double AHR7Day { get; set; }
        [DataMember(Name = "OverallAHR")]
        public double OverallAHR { get; set; }
        [DataMember(Name = "SDAR3Day")]
        public double SDAR3Day { get; set; }
        [DataMember(Name = "SDAR7Day")]
        public double SDAR7Day { get; set; }
        [DataMember(Name = "OverallSDAR")]
        public double OverallSDAR { get; set; }
        [DataMember(Name = "SDHR3Day")]
        public double SDHR3Day { get; set; }
        [DataMember(Name = "SDHR7Day")]
        public double SDHR7Day { get; set; }
        [DataMember(Name = "OverallSDHR")]
        public double OverallSDHR { get; set; }
        [DataMember(Name = "SDAHR3Day")]
        public double SDAHR3Day { get; set; }
        [DataMember(Name = "SDAHR7Day")]
        public double SDAHR7Day { get; set; }
        [DataMember(Name = "OverallSDAHR")]
        public double OverallSDAHR { get; set; }
        [DataMember(Name = "SDWorkedVol")]
        public double SDWorkedVol { get; set; }
	
    }
}
