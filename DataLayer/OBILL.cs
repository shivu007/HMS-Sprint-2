//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class OBILL
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
