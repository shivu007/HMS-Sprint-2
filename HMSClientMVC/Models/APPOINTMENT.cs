using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HMSClientMVC.CustomValidation;
namespace HMSClientMVC.Models
{
    public class APPOINTMENT
    {
        [Required]
        public string DoctorID { get; set; }

        public string AppointmentID { get; set; }
        public DateTime AppointmentDate { get; set; }
        [Required]
        public string PID { get; set; }
        public virtual DOCTOR DOCTOR { get; set; }
        public virtual PATIENT PATIENT { get; set; }
        
        public virtual ICollection<IBILL> IBILLs { get; set; }
    }
    
}