namespace Test.FV
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachSan")]
    public partial class KhachSan
    {
        [Key]
        [StringLength(50)]
        public string MaKS { get; set; }

        [StringLength(50)]
        public string TenKS { get; set; }

        public int? SDT { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string MaDDDL { get; set; }

        public virtual DiaDiemDL DiaDiemDL { get; set; }
    }
}
