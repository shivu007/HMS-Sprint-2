using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSWebAPI.Models
{
    public class Test
    {
        public string LabID { get; set; }
        public string PID { get; set; }
        public string TestType { get; set; }
        public Nullable<System.DateTime> TestDate { get; set; }
        public string Remark { get; set; }
        public string DoctorName { get; set; }

        public virtual PATIENT PATIENT { get; set; }
    }
}