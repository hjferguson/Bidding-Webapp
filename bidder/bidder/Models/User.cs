using System;
using System.ComponentModel.DataAnnotations;

namespace bidder.Models
{
	public class User
	{
		[Key]
		public int? userID { get; set;}

		public string? username { get; set; }
        public string? password { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public bool? verifiedStatus { get; set; }
        public string? email { get; set; }
		public string Slug => firstName.Replace(" ", "-").ToLower() + "-" + lastName.Replace(" ", "-").ToLower();




        public User(int userID, string username, string password, string email)
		{
			this.userID = userID;
			this.username = username;
			this.password = password;
			this.email = email;
			verifiedStatus = false;

		}

		public User() { }




	}
}

