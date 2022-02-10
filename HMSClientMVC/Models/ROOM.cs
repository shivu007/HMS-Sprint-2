using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HMSClientMVC.Models
{
    public class ROOM
    {
        [Required]
        public string RoomNo { get; set; }
        [Required]
        public string RoomType { get; set; }
        [Required]
        public Nullable<int> RoomCharge { get; set; }
    }
}