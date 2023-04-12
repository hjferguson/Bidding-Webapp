using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bidder.Models
{
	public class Bid
	{
		[Key]
		public int Id;
        [Required]
        public Auction auction;
		[Required]
		[ForeignKey("auctionID")]
		public int auctionID;
		[Required]
		public User user;
		public double amount;


		public Bid()
		{
		}
	}
}

