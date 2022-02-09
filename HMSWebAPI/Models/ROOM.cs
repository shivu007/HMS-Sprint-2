using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSWebAPI.Models
{
    public class ROOM
    {
        public string RoomNo { get; set; }
        public string RoomType { get; set; }
        public Nullable<int> RoomCharge { get; set; }
    }
}