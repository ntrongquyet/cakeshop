//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CakeShop.SQL
{
    using System;
    using System.Collections.Generic;
    
    public partial class BANH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BANH()
        {
            this.CT_DONHANG = new HashSet<CT_DONHANG>();
        }
    
        public int ID { get; set; }
        public string MABANH { get; set; }
        public string TENBANH { get; set; }
        public string DVT { get; set; }
        public Nullable<double> SL_TON { get; set; }
        public Nullable<double> DONGIA { get; set; }
        public string HA_BANH { get; set; }
        public string THONGTIN { get; set; }
        public string LOAIBANH { get; set; }
    
        public virtual LOAIBANH LOAIBANH1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_DONHANG> CT_DONHANG { get; set; }
    }
}
