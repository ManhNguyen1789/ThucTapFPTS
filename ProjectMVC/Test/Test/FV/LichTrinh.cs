namespace Test.FV
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LichTrinh")]
    public partial class LichTrinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LichTrinh()
        {
            Bookings = new HashSet<Booking>();
        }

        [Key]
        [StringLength(50)]
        public string MaLT { get; set; }

        public DateTime? NgayBD { get; set; }

        public DateTime? NgayKT { get; set; }

        [StringLength(50)]
        public string MaTour { get; set; }

        [StringLength(50)]
        public string MaPT { get; set; }

        public int? Slot { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual PhuongTien PhuongTien { get; set; }

        public virtual Tour Tour { get; set; }
    }
}
