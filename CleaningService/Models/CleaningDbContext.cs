namespace CleaningService.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CleaningDbContext : DbContext
    {
        public CleaningDbContext()
            : base("name=CleaningDbContext")
        {
        }

        public virtual DbSet<address> addresses { get; set; }
        public virtual DbSet<client> clients { get; set; }
        public virtual DbSet<country> countries { get; set; }
        public virtual DbSet<email> emails { get; set; }
        public virtual DbSet<invoice> invoices { get; set; }
        public virtual DbSet<invoices_positions> invoices_positions { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<phone_numbers> phone_numbers { get; set; }
        public virtual DbSet<service> services { get; set; }
        public virtual DbSet<staff> staffs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<address>()
                .Property(e => e.country_code)
                .IsUnicode(false);

            modelBuilder.Entity<address>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<address>()
                .Property(e => e.addr)
                .IsUnicode(false);

            modelBuilder.Entity<address>()
                .Property(e => e.postal_code)
                .IsUnicode(false);

            modelBuilder.Entity<address>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<address>()
                .HasMany(e => e.clients)
                .WithMany(e => e.addresses)
                .Map(m => m.ToTable("clients_addresses", "viie"));

            modelBuilder.Entity<address>()
                .HasMany(e => e.orders)
                .WithMany(e => e.addresses)
                .Map(m => m.ToTable("orders_addresses", "viie"));

            modelBuilder.Entity<address>()
                .HasMany(e => e.staffs)
                .WithMany(e => e.addresses)
                .Map(m => m.ToTable("staff_addresses", "viie"));

            modelBuilder.Entity<client>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.company)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .HasMany(e => e.orders)
                .WithRequired(e => e.client)
                .HasForeignKey(e => e.client_id);

            modelBuilder.Entity<client>()
                .HasMany(e => e.emails)
                .WithMany(e => e.clients)
                .Map(m => m.ToTable("clients_emails", "viie"));

            modelBuilder.Entity<client>()
                .HasMany(e => e.phone_numbers)
                .WithMany(e => e.clients)
                .Map(m => m.ToTable("clients_phone_numbers", "viie").MapRightKey("phone_number_id"));

            modelBuilder.Entity<country>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<country>()
                .HasMany(e => e.addresses)
                .WithRequired(e => e.country)
                .HasForeignKey(e => e.country_code);

            modelBuilder.Entity<email>()
                .Property(e => e.value)
                .IsUnicode(false);

            modelBuilder.Entity<email>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<email>()
                .HasMany(e => e.staffs)
                .WithMany(e => e.emails)
                .Map(m => m.ToTable("staff_emails", "viie"));

            modelBuilder.Entity<invoice>()
                .HasMany(e => e.invoices_positions)
                .WithRequired(e => e.invoice)
                .HasForeignKey(e => e.invoice_id);

            modelBuilder.Entity<invoice>()
                .HasMany(e => e.orders)
                .WithMany(e => e.invoices)
                .Map(m => m.ToTable("orders_invoices", "viie"));

            modelBuilder.Entity<invoices_positions>()
                .Property(e => e.duration)
                .HasPrecision(10, 2);

            modelBuilder.Entity<invoices_positions>()
                .Property(e => e.price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<order>()
                .Property(e => e.duration)
                .HasPrecision(10, 2);

            modelBuilder.Entity<order>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<order>()
                .HasMany(e => e.staffs)
                .WithMany(e => e.orders)
                .Map(m => m.ToTable("orders_staff", "viie"));

            modelBuilder.Entity<phone_numbers>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<phone_numbers>()
                .HasMany(e => e.staffs)
                .WithMany(e => e.phone_numbers)
                .Map(m => m.ToTable("staff_phone_numbers", "viie").MapLeftKey("phone_number_id"));

            modelBuilder.Entity<service>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<service>()
                .Property(e => e.price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<service>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<service>()
                .HasMany(e => e.invoices_positions)
                .WithRequired(e => e.service)
                .HasForeignKey(e => e.service_id);

            modelBuilder.Entity<staff>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.gender)
                .IsUnicode(false);
        }
    }
}
