using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSWebAPI.Models
{
    public class OBILL
    {
        public string BillNo { get; set; }
        public Nullable<decimal> MedicineFees { get; set; }
        public Nullable<decimal> RoomCharges { get; set; }
        public Nullable<decimal> OperationCharges { get; set; }
        public Nullable<decimal> LabFees { get; set; }
        public Nullable<decimal> DoctorFees { get; set; }
        public Nullable<decimal> TotalDays { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public string ADMISSIONID { get; set; }

        public virtual OPATIENT OPATIENT { get; set; }
    }
}