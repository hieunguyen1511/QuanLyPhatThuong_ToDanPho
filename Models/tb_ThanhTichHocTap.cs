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
    
    public partial class tb_ThanhTichHocTap
    {
        public int ID { get; set; }
        public int ID_ThanhVien { get; set; }
        public string ThanhTich { get; set; }
        public Nullable<int> XepLoai { get; set; }
    
        public virtual tb_ThanhVien tb_ThanhVien { get; set; }
    }
}