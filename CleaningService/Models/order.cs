namespace CleaningService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("viie.orders")]
    public partial class order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public order()
        {
            addresses = new HashSet<address>();
            invoices = new HashSet<invoice>();
            staffs = new HashSet<staff>();
        }

        public int id { get; set; }

        public int client_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime start_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? end_date { get; set; }

        public TimeSpan start_time { get; set; }

        public TimeSpan? end_time { get; set; }

        public decimal duration { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public virtual client client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<address> addresses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<invoice> invoices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<staff> staffs { get; set; }
    }
}
