using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSWebAPI.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Pass { get; set; }
        public string Roles { get; set; }

        
       // public virtual ICollection<DOCTOR> DOCTORs { get; set; }
      
        //public virtual ICollection<PATIENT> PATIENTs { get; set; }
    }
}