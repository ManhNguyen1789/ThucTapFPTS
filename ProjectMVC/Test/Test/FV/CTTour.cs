namespace Test.FV
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTTour")]
    public partial class CTTour
    {
        [Key]
        [StringLength(50)]
        public string MaCTTour { get; set; }

        [StringLength(50)]
        public string MaTour { get; set; }

        [StringLength(50)]
        public string MaDDDL { get; set; }

        [StringLength(50)]
        public string MaKS { get; set; }

        [StringLength(50)]
        public string MoTaCT { get; set; }

        public int? GiaveNL { get; set; }

        public int? GiaVeTE { get; set; }

        [StringLength(50)]
        public string MaLPT { get; set; }

        public virtual DiaDiemDL DiaDiemDL { get; set; }

        public virtual LoaiPhuongTien LoaiPhuongTien { get; set; }

        public virtual Tour Tour { get; set; }
    }
}
