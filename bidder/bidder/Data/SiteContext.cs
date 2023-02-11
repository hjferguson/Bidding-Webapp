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

        public DbSet<Auction> Auctions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Bid> Bids { get; set; }
    }
}

