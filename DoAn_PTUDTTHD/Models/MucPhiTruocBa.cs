//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAn_PTUDTTHD.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MucPhiTruocBa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MucPhiTruocBa()
        {
            this.YeuCauDangKyXes = new HashSet<YeuCauDangKyXe>();
        }
    
        public int ID { get; set; }
        public Nullable<bool> LoaiXe { get; set; }
        public Nullable<int> KhuVuc { get; set; }
        public Nullable<decimal> MucPhi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<YeuCauDangKyXe> YeuCauDangKyXes { get; set; }
    }
}
