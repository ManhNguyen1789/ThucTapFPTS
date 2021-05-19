namespace Test.FV
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiPhuongTien")]
    public partial class LoaiPhuongTien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiPhuongTien()
        {
            CTTours = new HashSet<CTTour>();
            PhuongTiens = new HashSet<PhuongTien>();
        }

        [Key]
        [StringLength(50)]
        public string MaLPT { get; set; }

        [StringLength(50)]
        public string TenLPT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTTour> CTTours { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhuongTien> PhuongTiens { get; set; }
    }
}
