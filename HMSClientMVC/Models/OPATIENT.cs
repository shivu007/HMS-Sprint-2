using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HMSClientMVC.Models
{
    public class OPATIENT
    {
        [Required]
        public string ADMISSIONID { get; set; }
        [Required]
        public string PID { get; set; }
        [Required]
        public string DID { get; set; }
        [Required]
        public System.DateTime ADMISSION_DATE { get; set; }
        [Required]
        public System.DateTime DISCHARGE_DATE { get; set; }
        [Required]
        public string RoomType { get; set; }
        [Required]

        public virtual DOCTOR DOCTOR { get; set; }

        [Required]
        public virtual ICollection<OBILL> OBILLs { get; set; }
        [Required]
        public virtual PATIENT PATIENT { get; set; }
    }
}