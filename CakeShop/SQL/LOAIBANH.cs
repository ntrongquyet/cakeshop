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
    
    public partial class LOAIBANH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAIBANH()
        {
            this.BANHs = new HashSet<BANH>();
        }
    
        public int ID { get; set; }
        public string MALOAI { get; set; }
        public string TENLOAI { get; set; }
        public string HA_LOAIBANH { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BANH> BANHs { get; set; }
    }
}
