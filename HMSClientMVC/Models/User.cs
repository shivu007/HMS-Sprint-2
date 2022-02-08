using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace HMSClientMVC.Models
{
    
    public class User
    {
        [Key]
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Username { get; set; }

        public string Pass { get; set; }
        public string Roles { get; set; }

        public enum role
        { Patient, Doctor }


        // public virtual ICollection<DOCTOR> DOCTORs { get; set; }

        //public virtual ICollection<PATIENT> PATIENTs { get; set; }
    }
}