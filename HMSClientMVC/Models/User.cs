using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace HMSClientMVC.Models
{
    
    public class User
    {
      
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Username { get; set; }
        [Required]
        public string Pass { get; set; }
        [Required]
        public string Roles { get; set; }
        public virtual ICollection<DOCTOR> DOCTORs { get; set; }

        public virtual ICollection<PATIENT> PATIENTs { get; set; }
    }
}