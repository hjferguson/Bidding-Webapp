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
		public string itemName { get; set; }
		public string itemDescription { get; set; }
		public double startingBid { get; set; }
        public double currentBid { get; set; }
        public double winningBid { get; set; }
        public DateTime startTime { get; set; }
		public DateTime endTime { get; set; }
		public string condition { get; set; }
		public string type { get; set; }
		public int buyerId { get; set; }
		public string image { get; set; }

		public int getID()
		{
			return Id;
		}

	}
}

