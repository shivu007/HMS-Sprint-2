using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HMSClientMVC.Models
{
    public class IBILL
    {
        [Required]
        public string BillNo { get; set; }
        [Required]
        public Nullable<decimal> MedicineFees { get; set; }
        [Required]
        public Nullable<decimal> OperationCharges { get; set; }
        [Required]
        public Nullable<decimal> LabFees { get; set; }
        [Required]
        public Nullable<decimal> DoctorFees { get; set; }
        [Required]
        public Nullable<decimal> TotalAmount { get; set; }
        [Required]
        public string APPOINTMENTID { get; set; }
        [Required]

        public virtual APPOINTMENT APPOINTMENT { get; set; }
    }
}