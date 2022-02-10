using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace HMSClientMVC.Models
{
    public class PATIENT
    {
        [Required]
        public string PID { get; set; }
        [Required]
        public string PName { get; set; }
        [Required]
        public string PGender { get; set; }
        [Required]
        public System.DateTime Pdob { get; set; }
        [Required]
        public int PWeight { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Disease { get; set; }
        [Required]
        public string PAddress { get; set; }
        [Required]
        public string PatientType { get; set; }
        [Required]
        public string Username { get; set; }

        [Required]
        public virtual ICollection<APPOINTMENT> APPOINTMENTs { get; set; }
        [Required]
        public virtual ICollection<OPATIENT> OPATIENTs { get; set; }
        [Required]
        public virtual ICollection<Test> Tests { get; set; }
    }
}