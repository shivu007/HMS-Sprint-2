using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HMSClientMVC.Models
{
    public class Test
    {
     
        public string LabID { get; set; }
        [Required (ErrorMessage ="Please select PID")]
        public string PID { get; set; }
        [Required(ErrorMessage = "Please select test type")]
        public string TestType { get; set; }
        [Required(ErrorMessage = "Please select test date")]
        public Nullable<System.DateTime> TestDate { get; set; }
        [Required]
        public string Remark { get; set; }
        [Required]
        public string DoctorName { get; set; }
        [Required]
        public virtual PATIENT PATIENT { get; set; }
    }
}