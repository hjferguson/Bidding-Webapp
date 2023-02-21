using System;
using bidder.Models;

namespace bidder
{
	public class Auction
	{
		public int auctionID { get; set; }
		public Bid[] bidList;
		public string itemName;
		public double startingBid;
		public double reservePrice;
		public DateTime auctionStart;
		public DateTime auctionEnd;
		public string condition;
		public string category;
		public User seller;
		public User winner;




		public Auction(int auctionID, string itemName, User seller)
		{
			this.auctionID = auctionID;
			this.itemName = itemName;

		}


		public int getID()
		{
			return auctionID;
		}

		public string getItemName()
		{
			return itemName;
		}

		public double getStartingBid()
		{
			return startingBid;
		}

		public void setStartingBid(double startingBid)
		{
			this.startingBid = startingBid;
		}
	}
}

