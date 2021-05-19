namespace Test.FV
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tour")]
    public partial class Tour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tour()
        {
            CTTours = new HashSet<CTTour>();
            LichTrinhs = new HashSet<LichTrinh>();
            Media = new HashSet<Medium>();
        }

        [Key]
        [StringLength(50)]
        public string MaTour { get; set; }

        [StringLength(50)]
        public string TenTour { get; set; }

        [StringLength(50)]
        public string MaLoaiTour { get; set; }

        public int? GiaTien { get; set; }

        public int? Minuser { get; set; }

        public int? Maxuser { get; set; }

        public string MoTa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTTour> CTTours { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichTrinh> LichTrinhs { get; set; }

        public virtual LoaiTour LoaiTour { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medium> Media { get; set; }
    }
}
