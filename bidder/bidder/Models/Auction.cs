// Auction.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using bidder.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace bidder
{
    public class Auction
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Creator")]
        public int CreatorId { get; set; }
        public User Creator { get; set; }

        public string itemName { get; set; }
        public string itemDescription { get; set; }
        public double startingBid { get; set; }
        public double currentBid { get; set; }
        public double winningBid { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string condition { get; set; }
        public string type { get; set; }

        [ForeignKey("winnerId")]
        public int? winnerId { get; set; }
        //public User Winner { get; set; }

        public string image { get; set; }

        public ICollection<Bid> Bids { get; set; } // Add this line

        public int getID()
        {
            return Id;
        }
    }
}
