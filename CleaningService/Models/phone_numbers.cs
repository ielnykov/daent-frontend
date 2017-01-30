namespace CleaningService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Globalization;

    [Table("viie.phone_numbers")]
    public partial class phone_numbers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public phone_numbers()
        {
            clients = new HashSet<client>();
            staffs = new HashSet<staff>();
        }

        public int id { get; set; }

        [Column("number")]
        [Display(Name = "Phone Number")]
        public long value { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Type")]
        public string type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<client> clients { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<staff> staffs { get; set; }

        public string typeIcon
        {
            get
            {
                string icon = "";
                string desc = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(this.type.ToLower());
                switch (this.type)
                {
                    case "PRIVATE":
                        icon = "user-secret";
                        break;
                    case "WORK":
                        icon = "briefcase";
                        break;
                }
                return String.Format("<i class=\"fa fa-{0}\"></i> {1}", icon, desc);
            }
        }
    }
}
