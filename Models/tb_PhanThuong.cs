//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyPhatThuong_ToDanPho_1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_PhanThuong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_PhanThuong()
        {
            this.tb_ChiTietPhatThuong = new HashSet<tb_ChiTietPhatThuong>();
        }
    
        public int ID { get; set; }
        public int ID_LoaiPhanThuong { get; set; }
        public string TenPhanThuong { get; set; }
        public string DVT { get; set; }
        public Nullable<int> TriGia { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_ChiTietPhatThuong> tb_ChiTietPhatThuong { get; set; }
        public virtual tb_LoaiPhanThuong tb_LoaiPhanThuong { get; set; }
    }
}