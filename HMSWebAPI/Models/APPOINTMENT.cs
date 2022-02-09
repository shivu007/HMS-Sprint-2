using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSWebAPI.Models
{
    public class APPOINTMENT
    {
        public string DoctorID { get; set; }
        public string AppointmentID { get; set; }
        public System.DateTime AppointmentDate { get; set; }
        public string PID { get; set; }

        public virtual DOCTOR DOCTOR { get; set; }
        public virtual PATIENT PATIENT { get; set; }

        public virtual ICollection<IBILL> IBILLs { get; set; }
    }
}