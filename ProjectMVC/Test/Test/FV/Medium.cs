namespace Test.FV
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Medium
    {
        [Key]
        public int ID_Media { get; set; }

        [StringLength(50)]
        public string Url { get; set; }

        public bool? Main { get; set; }

        [StringLength(50)]
        public string MaTour { get; set; }

        public virtual Tour Tour { get; set; }
    }
}
