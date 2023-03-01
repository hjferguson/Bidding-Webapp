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
            modelBuilder.Entity<Auction>().HasKey(a => a.Id);
            modelBuilder.Entity<Auction>().HasData(
                new Auction() {Id = 1, itemName = "Buffalo", itemDescription = "Buffalo", startingBid = 15, startTime = DateTime.Now, endTime = DateTime.Now, condition = "New", type = "Buffalo", image = "Buffalo" });

            modelBuilder.Entity<User>().HasData(
                new User() {userID = 1, username = "buyer", password = "buyer", passwordConfirm = "buyer", email = "buyer@gmail.com", seller = false, buyer = true, firstName = "buy", lastName = "er" },
                new User() {userID = 2, username = "seller", password = "seller", passwordConfirm = "seller", email = "seller@gmail.com", seller = true, buyer = false, firstName = "sel", lastName = "ler" });
                

        }
    }
}