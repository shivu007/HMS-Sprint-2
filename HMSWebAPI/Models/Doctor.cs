using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSWebAPI.Models
{
    public class Doctor
    {
        public string DID { get; set; }
        public string Dept { get; set; }
        public string Dname { get; set; }
        public string Username { get; set; }


        //public virtual ICollection<APPOINTMENT> APPOINTMENTs { get; set; }

        //public virtual ICollection<OPATIENT> OPATIENTs { get; set; }
        public virtual User User { get; set; }
    }
}