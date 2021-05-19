using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class NhanVien
    {
        [Required]
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public string NghiepVu { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string Taikhoan { get; set; }
        public int SDT { get; set; }
        public string PassWord { get; set; }
    }
    
}