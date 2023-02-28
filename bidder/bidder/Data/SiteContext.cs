using System;
using bidder.Models;
using Microsoft.EntityFrameworkCore;

namespace bidder.Data
{
    public class SiteContext : DbContext
    {
        public SiteContext(DbContextOptions<SiteContext> options) : base(options)
        {
        }

        public DbSet<Auction>? Auctions { get; set; }
        public DbSet<User>? Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auction>()
       .HasKey(a => a.Id);
            modelBuilder.Entity<Auction>().HasData(
                new Auction(01, "Buffalo", 01));

            modelBuilder.Entity<User>().HasData(
                new User(1, "buyer", "buyer", "buyer@gmail.com", "Buyer"));
                new User(2, "seller", "seller", "seller@gmail.com", "Seller");




        }
    }
}

