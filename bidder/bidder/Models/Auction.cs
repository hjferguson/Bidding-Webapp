using System;
using System.ComponentModel.DataAnnotations;
using bidder.Models;

namespace bidder
{
	public class Auction
	{
		[Key]
		int auctionID;
		string itemName;
		double startingBid;
		DateTime startTime;
		DateTime endTime;
		User seller;




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

