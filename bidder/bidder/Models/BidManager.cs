using System;
namespace bidder.Models
{
	public class BidManager
	{
		private int maxBids;
		private int numBids;
		private Bid[] bidList;

		
		public BidManager(int size)
		{
			this.maxBids = size;
			numBids = 0;
			bidList = new Bid[maxBids];
		}





	}
}

