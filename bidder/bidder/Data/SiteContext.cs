using bidder.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace bidder.Data
{
    public class SiteContext : DbContext
    {
        public SiteContext(DbContextOptions<SiteContext> options) : base(options)
        {
        }

        public DbSet<Auction>? Auctions { get; set; }
        public DbSet<User>? Users { get; set; }

        public DbSet<Bid> Bids { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auction>().HasKey(a => a.Id);
            modelBuilder.Entity<Auction>().HasData(
                new Auction()
                {
                    Id = 1,
                    itemName = "Buffalo",
                    itemDescription = "Buffalo",
                    startingBid = 15,
                    startTime = DateTime.Now,
                    endTime = DateTime.Now,
                    condition = "New",
                    type = "Buffalo",
                    winnerId  = null,
                    image = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/13/African_buffalo_%28Syncerus_caffer_caffer%29_male_with_cattle_egret.jpg/1200px-African_buffalo_%28Syncerus_caffer_caffer%29_male_with_cattle_egret.jpg",
                    currentBid = 0,
                    winningBid = 0
                });

            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    userID = 1,
                    username = "buyer",
                    password = "123Password1$",
                    passwordConfirm = "123Password1$",
                    email = "buyer@gmail.com",
                    seller = false,
                    buyer = true,
                    admin = false,
                    firstName = "buy",
                    lastName = "er",
                    verifiedStatus = true
                },
                new User()
                {
                    userID = 2,
                    username = "seller",
                    password = "123Password1$",
                    passwordConfirm = "123Password1$",
                    email = "seller@gmail.com",
                    seller = true,
                    buyer = false,
                    admin = false,
                    firstName = "sel",
                    lastName = "ler",
                    verifiedStatus = true
                },
                new User()
                {
                    userID = 3,
                    username = "admin",
                    password = "123Password1$",
                    passwordConfirm = "123Password1$",
                    email = "admin@gmail.com",
                    seller = false,
                    buyer = true,
                    admin = true,
                    firstName = "ad",
                    lastName = "min",
                    verifiedStatus = true
                });
        }
    }
}
