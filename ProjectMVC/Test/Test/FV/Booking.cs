namespace Test.FV
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        [Key]
        public int MaVe { get; set; }

        [StringLength(50)]
        public string MaTour { get; set; }

        public int? SLNguoiLon { get; set; }

        public int? SLTreEm { get; set; }

        [StringLength(50)]
        public string MaLT { get; set; }

        [StringLength(50)]
        public string MaKH { get; set; }

        [StringLength(50)]
        public string MaDDDL { get; set; }

        [StringLength(50)]
        public string MaNV { get; set; }

        public int? TrangThai { get; set; }

        public int? GiaTien { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayBook { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual LichTrinh LichTrinh { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
