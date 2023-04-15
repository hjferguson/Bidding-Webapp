using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace bidder.Models
{
    public class User
    {
        [Key]
        public int userID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string passwordConfirm { get; set; }
        public string email { get; set; }
        public bool seller { get; set; }
        public bool buyer { get; set; }
        public bool admin { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public bool verifiedStatus { get; set; }

        // Navigation properties
        public ICollection<Review> reviews { get; set; }
        public ICollection<Auction> CreatedAuctions { get; set; }
        public ICollection<Bid> Bids { get; set; }

        public ICollection<Cart> Carts { get; set; }
    }
}
