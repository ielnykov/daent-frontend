namespace CleaningService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("viie.clients")]
    public partial class client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public client()
        {
            orders = new HashSet<order>();
            addresses = new HashSet<address>();
            emails = new HashSet<email>();
            phone_numbers = new HashSet<phone_numbers>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "First Name")]
        public string first_name { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string last_name { get; set; }

        [StringLength(255)]
        [Display(Name = "Company Name")]
        public string company { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<address> addresses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<email> emails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<phone_numbers> phone_numbers { get; set; }
    }
}
