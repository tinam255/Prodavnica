namespace Prodavnica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("proizvodi")]
    public partial class proizvodi
    {
        public int id { get; set; }

        [StringLength(50)]
        public string naziv { get; set; }

        public int? kat_id { get; set; }

        public int? dob_id { get; set; }

        public int? pr_id { get; set; }

        public decimal? cena { get; set; }

        public virtual dobavljaci dobavljaci { get; set; }

        public virtual kategorije kategorije { get; set; }

        public virtual proizvodjaci proizvodjaci { get; set; }
    }
}
