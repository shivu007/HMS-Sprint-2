using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSClientMVC.Models
{
    public class PATIENT
    {

        public string PID { get; set; }
        public string PName { get; set; }
        public string PGender { get; set; }
        public System.DateTime Pdob { get; set; }
        public int PWeight { get; set; }
        public string PhoneNumber { get; set; }
        public string Disease { get; set; }
        public string PAddress { get; set; }
        public string PatientType { get; set; }
        public string Username { get; set; }


        public virtual ICollection<APPOINTMENT> APPOINTMENTs { get; set; }
  
        public virtual ICollection<OPATIENT> OPATIENTs { get; set; }

        public virtual ICollection<Test> Tests { get; set; }
    }
}