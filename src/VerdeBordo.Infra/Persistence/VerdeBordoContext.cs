using Microsoft.EntityFrameworkCore;
using VerdeBordo.Domain.Entities;

namespace VerdeBordo.Infra.Persistence
{
    public class VerdeBordoContext : DbContext
    {
        #region DbSets

        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Embroidery>? Orders { get; set; }
        public DbSet<Address>? Addresses { get; set; }

        #endregion

        #region Constructor

        public VerdeBordoContext(DbContextOptions<VerdeBordoContext> dbContextOptions)
            : base(dbContextOptions)
        { }

        #endregion

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(c =>
            {
                c.HasKey(c => c.Id);

                c.HasMany(c => c.Orders)
                    .WithOne()
                    .HasForeignKey(e => e.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);

                c.HasMany(c => c.Addresses)
                    .WithOne()
                    .HasForeignKey(a => a.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Embroidery>(e =>
            {
                e.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Address>(a =>
            {
                a.HasKey(e => e.Id);
            });
        }

        #endregion

    }
}
