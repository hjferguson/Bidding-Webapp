using System;
using System.ComponentModel.DataAnnotations;
using bidder.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace bidder
{
	public class Auction
	{
		[Key]
		public int Id { get; set; }
		public string? itemName { get; set; }
		public double? startingBid { get; set; }
		public DateTime? startTime { get; set; }
		public DateTime? endTime { get; set; }
		public User? seller { get; set; }
		public int? sellerId { get; set; }


		public Auction(int Id, string itemName, int sellerId)
		{
			this.Id = Id;
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

