namespace Prodavnica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dobavljaci")]
    public partial class dobavljaci
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dobavljaci()
        {
            proizvodis = new HashSet<proizvodi>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string dobavljac { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<proizvodi> proizvodis { get; set; }
    }
}
