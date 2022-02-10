using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HMSClientMVC.Models
{
    public class DOCTOR
    {
        [Required]
        public string DID { get; set; }
        [Required(ErrorMessage = "Please Provide Department")]
        public string Dept { get; set; }
        [Required]
        public string Dname { get; set; }
        [Required]
        public string Username { get; set; }

     
        public virtual ICollection<APPOINTMENT> APPOINTMENTs { get; set; }
       
        public virtual ICollection<OPATIENT> OPATIENTs { get; set; }
        public virtual User User { get; set; }
    }
}