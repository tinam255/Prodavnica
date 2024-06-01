namespace Prodavnica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("proizvodjaci")]
    public partial class proizvodjaci
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public proizvodjaci()
        {
            proizvodis = new HashSet<proizvodi>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string proizvodjac { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<proizvodi> proizvodis { get; set; }
    }
}
