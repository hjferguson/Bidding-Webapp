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

        public DbSet<Auction> Auctions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public DbSet<Review> Review { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auction>().HasKey(a => a.Id);
            modelBuilder.Entity<User>().HasKey(u => u.userID);
            modelBuilder.Entity<Bid>().HasKey(b => b.Id);
            
            modelBuilder.Entity<Auction>()
                .HasOne(a => a.Creator)
                .WithMany(u => u.CreatedAuctions)
                .HasForeignKey(a => a.CreatorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
       
            modelBuilder.Entity<Bid>()
                .HasOne(b => b.Auction)
                .WithMany(a => a.Bids)
                .HasForeignKey(b => b.AuctionID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Bid>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bids)
                .HasForeignKey(b => b.UserID)
                .OnDelete(DeleteBehavior.Restrict);

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
                    winnerId = null,
                    image = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/13/African_buffalo_%28Syncerus_caffer_caffer%29_male_with_cattle_egret.jpg/1200px-African_buffalo_%28Syncerus_caffer_caffer%29_male_with_cattle_egret.jpg",
                    currentBid = 0,
                    winningBid = 15,
                    CreatorId = 2
                },

                new Auction()
                {
                    Id = 2,
                    itemName = "Mark Ruffalo Signed Poster",
                    itemDescription = "Signed by us",
                    startingBid = 15,
                    startTime = DateTime.Now,
                    endTime = DateTime.Now.AddMinutes(5),
                    condition = "New",
                    type = "Collectibe",
                    winnerId = null,
                    image = "https://static.displate.com/857x1200/displate/2020-11-13/82125307287b2e5a94c8cfb31e6ecc79_27a3dc812489a692d79f3ef7d63be919.jpg",
                    currentBid = 15,
                    winningBid = 0,
                    CreatorId = 2
               
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
