namespace Test.FV
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TourDLContext : DbContext
    {
        public TourDLContext()
            : base("name=TourDLContext")
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<CTTour> CTTours { get; set; }
        public virtual DbSet<DiaDiemDL> DiaDiemDLs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<KhachSan> KhachSans { get; set; }
        public virtual DbSet<LichTrinh> LichTrinhs { get; set; }
        public virtual DbSet<LoaiPhuongTien> LoaiPhuongTiens { get; set; }
        public virtual DbSet<LoaiTour> LoaiTours { get; set; }
        public virtual DbSet<Medium> Media { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhuongTien> PhuongTiens { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
