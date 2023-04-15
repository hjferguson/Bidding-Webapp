using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bidder.Models
{
    public class Bid
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Auction")]
        public int AuctionID { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserID { get; set; }

        [Required]
        public double Amount { get; set; }

        // Navigation properties
        public Auction Auction { get; set; }
        public User User { get; set; }

        public Bid()
        {
        }
    }
}
