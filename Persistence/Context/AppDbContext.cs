using filed.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace filed.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentState> PaymentStates { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Payment>().ToTable("Payments");
            builder.Entity<Payment>().HasKey(p => p.Id);
            builder.Entity<Payment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Payment>().Property(p => p.CreditCardNumber).IsRequired().HasMaxLength(30);
            builder.Entity<Payment>().Property(p => p.CardHolder).IsRequired();
            builder.Entity<Payment>().Property(p => p.ExpirationDate).IsRequired();
            builder.Entity<Payment>().Property(p => p.SecurityCode).HasMaxLength(3);
            builder.Entity<Payment>().Property(p => p.Amount).IsRequired();


            builder.Entity<PaymentState>().ToTable("PaymentStates");
            builder.Entity<PaymentState>().HasKey(s => s.Id);
            builder.Entity<PaymentState>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<PaymentState>().Property(s => s.PaymentStatus).IsRequired();

            builder.Entity<Payment>().HasOne(p => p.State).WithOne(q => q.Payment).HasForeignKey<PaymentState>(r => r.PaymentId);

        }


    }
}