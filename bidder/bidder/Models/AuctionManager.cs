using System;
using System.Collections;
namespace bidder.Models
{
	public class AuctionManager
	{
		private Auction[] auctionList;
		private int numAuctions;
		private int auctionSeed;


		public AuctionManager()
		{
			ArrayList arr = new ArrayList();
			auctionSeed = 0;
		}

		public Auction? search(int id)
		{
			for (int x = 0; x < numAuctions; x++)
			{
				if (auctionList[x].getID() == id)
				{
					return auctionList[x];
				}
			}
			return null; 

		}



		public void addAuction(int auctionID, string itemName, int sellerID)
        {
			Auction temp = new Auction(auctionSeed, itemName, sellerID);
			auctionList[numAuctions] = temp;
			numAuctions++;	
		}








	}
}

