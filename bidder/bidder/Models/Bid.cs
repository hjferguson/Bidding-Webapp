using System;
using bidder.Models;
namespace bidder
{
	public class Bid
	{
		private int bidID { get; set;}
		private Auction auction { get; set; }
		private User user;
		private int amount;




		public Bid(int bidID, Auction auction, User user, int amount)
		{
			this.bidID = bidID;
			this.auction = auction;
			this.user = user;
			this.amount = amount;

		}
	}
}

