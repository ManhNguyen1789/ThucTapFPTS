namespace Test.FV
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slide")]
    public partial class Slide
    {
        [Key]
        [StringLength(50)]
        public string ID_Slide { get; set; }

        [StringLength(50)]
        public string TenSlide { get; set; }

        [StringLength(50)]
        public string Img { get; set; }

        [StringLength(500)]
        public string Link { get; set; }
    }
}
