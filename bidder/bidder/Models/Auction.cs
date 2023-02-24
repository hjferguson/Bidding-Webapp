using System;
using bidder.Models;
using System.ComponentModel.DataAnnotations;

namespace bidder
{
	public class Auction
	{
		[Key]
		public int auctionID { get; set; }
        public string? itemName { get; set; }


		
		public string? itemDescription { get; set; }

		public double startingBid { get; set; }
        public double? reservePrice { get; set; }

        public DateTime? auctionStart { get; set; }

        public DateTime? auctionEnd { get; set; }


        public string? condition { get; set; }




        public string? category { get; set; }

        public int? sellerID { get; set; }
        public User? seller { get; set; }




        public Auction(int auctionID, string itemName, int sellerID)
		{
			this.auctionID = auctionID;
			this.itemName = itemName;
			this.sellerID = sellerID;

		}

		public Auction() { }



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

