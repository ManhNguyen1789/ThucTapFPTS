//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Test
{
    using System;
    using System.Collections.Generic;
    
    public partial class Booking
    {
        public int MaVe { get; set; }
        public string MaTour { get; set; }
        public Nullable<int> SLNguoiLon { get; set; }
        public Nullable<int> SLTreEm { get; set; }
        public string MaLT { get; set; }
        public string MaKH { get; set; }
        public string MaDDDL { get; set; }
        public string MaNV { get; set; }
        public Nullable<int> TrangThai { get; set; }
        public Nullable<int> GiaTien { get; set; }
        public Nullable<System.DateTime> NgayBook { get; set; }
    
        public virtual KhachHang KhachHang { get; set; }
        public virtual LichTrinh LichTrinh { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}
