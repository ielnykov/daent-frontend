namespace CleaningService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Globalization;

    [Table("viie.addresses")]
    public partial class address
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public address()
        {
            clients = new HashSet<client>();
            orders = new HashSet<order>();
            staffs = new HashSet<staff>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(2)]
        [Display(Name = "Country")]
        public string country_code { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "City")]
        public string city { get; set; }

        [Column("address")]
        [Required]
        [StringLength(255)]
        [Display(Name = "Address")]
        public string addr { get; set; }

        [StringLength(20)]
        [Display(Name = "Postal Code")]
        public string postal_code { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Type")]
        public string type { get; set; }

        public virtual country country { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<client> clients { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> orders { get; set; }

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
                    case "HOME":
                        icon = "home";
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
