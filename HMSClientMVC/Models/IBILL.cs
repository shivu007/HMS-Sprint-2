using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSClientMVC.Models
{
    public class IBILL
    {
        public string BillNo { get; set; }
        public Nullable<decimal> MedicineFees { get; set; }
        public Nullable<decimal> OperationCharges { get; set; }
        public Nullable<decimal> LabFees { get; set; }
        public Nullable<decimal> DoctorFees { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public string APPOINTMENTID { get; set; }

        public virtual APPOINTMENT APPOINTMENT { get; set; }
    }
}