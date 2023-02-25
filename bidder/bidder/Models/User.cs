using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace bidder.Models
{
	public class User
	{
		[Key]
		public int userID { get; set; }
		public string? username { get; set; }
		public string? password { get; set; }
		public bool verifiedStatus { get; set;}
		public string? email { get; set; }




		public User(int userID, string username, string password, string email)
		{
			this.userID = userID;
			this.username = username;
			this.password = password;
			this.email = email;
			verifiedStatus = false;

		}

		public User() { }


		public void setVerified()
		{
			verifiedStatus = true;
		}

		public string getUsername()
		{
			return username;
		}

		public int getId()
		{
			return userID;
		}

		public string getPassword()
		{
			return password;
		}

		public string getEmail()
		{
			return email;
		}

		public bool getStatus()
		{
			return verifiedStatus;
		}




	}
}

