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
    
    public partial class OPATIENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OPATIENT()
        {
            this.OBILLs = new HashSet<OBILL>();
        }
    
        public string ADMISSIONID { get; set; }
        public string PID { get; set; }
        public string DID { get; set; }
        public System.DateTime ADMISSION_DATE { get; set; }
        public System.DateTime DISCHARGE_DATE { get; set; }
        public string RoomType { get; set; }
    
        public virtual DOCTOR DOCTOR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OBILL> OBILLs { get; set; }
        public virtual PATIENT PATIENT { get; set; }
    }
}
