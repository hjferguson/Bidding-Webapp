using System;
using bidder.Models;

namespace bidder
{
	public class Auction
	{
		int auctionID;
		Bid[] bidList;
		string itemName;
		double startingBid;
		double reservePrice;
		User seller;
		User winner;




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

