//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyPhatThuong
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_ChiTietPhatThuong
    {
        public int ID { get; set; }
        public Nullable<int> ID_DanhSachPhatThuong { get; set; }
        public Nullable<int> ID_NguoiNhan { get; set; }
        public Nullable<int> ID_ChiTietPhanThuong { get; set; }
        public int SoLuong { get; set; }
        public Nullable<bool> TrangThai { get; set; }
    
        public virtual tb_ChiTietPhanThuong tb_ChiTietPhanThuong { get; set; }
        public virtual tb_DanhSachPhatThuong tb_DanhSachPhatThuong { get; set; }
        public virtual tb_ThanhVienHoGiaDinh tb_ThanhVienHoGiaDinh { get; set; }
    }
}
