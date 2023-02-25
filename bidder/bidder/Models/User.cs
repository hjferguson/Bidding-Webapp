using System;
using System.ComponentModel.DataAnnotations;

namespace bidder.Models
{
	public class User
	{
		[Key]
		private int userID;
		private string? username;
		private string? password;
		private bool verifiedStatus;
		private string? email;




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

