﻿using CAR_RENTAL.Entites;
using Microsoft.EntityFrameworkCore;

namespace CAR_RENTAL.context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Booking> Bookings { get; set; }

    }
}