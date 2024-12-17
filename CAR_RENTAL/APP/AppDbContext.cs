using CAR_RENTAL.Entites;
using Microsoft.EntityFrameworkCore;

namespace CAR_RENTAL.context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<CustomerLogin> CustomerLogins { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Rent> Rents { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
               .HasMany(c => c.Bookings)
               .WithOne(b => b.customer)
               .HasForeignKey(b => b.CustomerId)
               .OnDelete(DeleteBehavior.Cascade);

            // Booking to Customer Relationship
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.customer)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Message to Customer Relationship
            modelBuilder.Entity<Message>()
                .HasOne(m => m.customer)
                .WithMany()
                .HasForeignKey(m => m.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Rent to Booking Relationship
            modelBuilder.Entity<Rent>()
               .HasOne(r => r.car)
               .WithMany()
               .HasForeignKey(r => r.CarId)
               .OnDelete(DeleteBehavior.Cascade);


            // Rent to Customer Relationship
            modelBuilder.Entity<Rent>()
                .HasOne(r => r.Customer)
                .WithMany()
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Rent to Car Relationship
            modelBuilder.Entity<Rent>()
                .HasOne(r => r.car)
                .WithMany()
                .HasForeignKey(r => r.CarId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
