using Microsoft.EntityFrameworkCore;
using VerdeBordo.Domain.Entities;

namespace VerdeBordo.Infra.Persistence
{
    public class VerdeBordoContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public VerdeBordoContext(DbContextOptions<VerdeBordoContext> dbContextOptions)
            : base(dbContextOptions)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(c =>
            {
                c.HasKey(c => c.Id);

                c.HasMany(c => c.Orders)
                    .WithOne()
                    .HasForeignKey(e => e.ClientId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
