using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSClientMVC.Models
{
    public class OPATIENT
    {
        public string ADMISSIONID { get; set; }
        public string PID { get; set; }
        public string DID { get; set; }
        public System.DateTime ADMISSION_DATE { get; set; }
        public System.DateTime DISCHARGE_DATE { get; set; }
        public string RoomType { get; set; }

        public virtual DOCTOR DOCTOR { get; set; }

        public virtual ICollection<OBILL> OBILLs { get; set; }
        public virtual PATIENT PATIENT { get; set; }
    }
}