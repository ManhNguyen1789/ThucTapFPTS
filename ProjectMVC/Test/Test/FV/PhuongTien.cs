namespace Test.FV
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhuongTien")]
    public partial class PhuongTien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhuongTien()
        {
            LichTrinhs = new HashSet<LichTrinh>();
        }

        [Key]
        [StringLength(50)]
        public string MaPT { get; set; }

        [StringLength(50)]
        public string TenPT { get; set; }

        public int? SoCho { get; set; }

        [StringLength(50)]
        public string MaLPT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichTrinh> LichTrinhs { get; set; }

        public virtual LoaiPhuongTien LoaiPhuongTien { get; set; }
    }
}
