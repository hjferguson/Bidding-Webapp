using System;
namespace bidder.Models
{
	public class User
	{
		private int userID;
		private string username;
		private string password;
		private bool verifiedStatus;
		private string email;
		private string name;
		private 




		public User(int userID, string username, string password, string email)
		{
			this.username = username;
			this.password = password;
			this.email = email;
			verifiedStatus = false;

		}

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

