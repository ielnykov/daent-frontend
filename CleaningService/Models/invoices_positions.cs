namespace CleaningService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("viie.invoices_positions")]
    public partial class invoices_positions
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int invoice_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int service_id { get; set; }

        public decimal duration { get; set; }

        public decimal price { get; set; }

        public virtual invoice invoice { get; set; }

        public virtual service service { get; set; }
    }
}
