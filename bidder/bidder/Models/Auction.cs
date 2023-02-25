using System;
using System.ComponentModel.DataAnnotations;
using bidder.Models;

namespace bidder
{
	public class Auction
	{
		[Key]
		int Id { get; set; }
		string? itemName { get; set; }
		double? startingBid { get; set; }
		DateTime? startTime { get; set; }
		DateTime? endTime { get; set; }
		User? seller { get; set; }




		public Auction(string itemName)
		{
			this.itemName = itemName;

		}

		public Auction() { }



		public int getID()
		{
			return Id;
		}

		public string getItemName()
		{
			return itemName;
		}


		public void setStartingBid(double startingBid)
		{
			this.startingBid = startingBid;
		}
	}
}

