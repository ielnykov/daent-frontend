namespace CleaningService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("viie.services")]
    public partial class service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public service()
        {
            invoices_positions = new HashSet<invoices_positions>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        public decimal price { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<invoices_positions> invoices_positions { get; set; }
    }
}
