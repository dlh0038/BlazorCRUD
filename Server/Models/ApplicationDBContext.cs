using BlazorCRUD.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.Server.Models
{
public partial class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {
        }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {
        }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("userdetails");
                entity.Property(e => e.Userid).HasColumnName("Userid");
                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.StreetAddress)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                entity.Property(e => e.Emailid)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
