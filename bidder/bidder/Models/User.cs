using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace bidder.Models
{
	public class User
	{
		[Key]
		public int userID { get; set; }
		public string username { get; set; }
		public string password { get; set; }
		public string passwordConfirm { get; set; }
        public string email { get; set; }
        public bool seller { get; set; }
		public bool buyer { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }
        public bool verifiedStatus { get; set; }



		/*
        public User(int userID, string username, string password, string passwordConfirm, string email, bool seller, bool buyer, string firstName, string lastName)
		{
			this.userID = userID;
			this.username = username;
			this.password = password;
			this.passwordConfirm = passwordConfirm;
			this.email = email;
			this.seller = seller;
			this.buyer = buyer;
			this.firstName = firstName;
			this.lastName = lastName;
			this.verifiedStatus = false;

		}
		*/
	}
}

