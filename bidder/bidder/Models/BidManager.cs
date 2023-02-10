using System;
namespace bidder.Models
{
	public class BidManager
	{
		private int IdSeed;
		private int maxBids;
		private int numBids;
		private Bid[] bidList;

		
		public BidManager(int size)
		{
			IdSeed = 0;
			this.maxBids = size;
			numBids = 0;
			bidList = new Bid[maxBids];
		}

		public int getMaxBids()
		{
			return maxBids;
		}

		public int getNumBids()
		{
			return numBids;
		}

		public Bid[] getBidList()
		{
			return bidList;
		}

		public Boolean addBid(Auction auction, User user, int amount)
		{
			Bid temp = new Bid(IdSeed, auction, user, amount);
			bidList

				//testing 
		}




	}
}

