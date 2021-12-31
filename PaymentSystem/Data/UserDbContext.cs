using Microsoft.EntityFrameworkCore;
using PaymentSystem.Core.Models;

namespace PaymentSystem.Data
{
    public partial class UserDbContext : DbContext
    {
        public DbSet<Payments> Payments { get; set; }
        public DbSet<User> Users { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        { }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Payments>(entity =>
            {
                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.AccountBalance)
                    .IsRequired()
                    .HasColumnName("AccountBalance")
                    .HasMaxLength(100);
            });


            OnModelCreatingPartial(modelBuilder);

        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
