using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HMSClientMVC.Models
{
    public class PATIENT
    {
        private string CurrBdate=DateTime.Now.ToString();
       

        public string PID { get; set; }
        [Required]
        public string PName { get; set; }
        [Required]
        public string PGender { get; set; }
        [Required]
       
       public System.DateTime Pdob { get;  set; }
        [Required]
        public int PWeight { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Disease { get; set; }
        [Required]
        public string PAddress { get; set; }
       
        public string PatientType { get; set; }
        public string Username { get; set; }


        public virtual ICollection<APPOINTMENT> APPOINTMENTs { get; set; }
  
        public virtual ICollection<OPATIENT> OPATIENTs { get; set; }

        public virtual ICollection<Test> Tests { get; set; }
    }
}