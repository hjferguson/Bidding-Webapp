using System;
namespace bidder.Models
{
	public class UserManager
	{
		private User[] userList;
		private int numUsers;
		private int maxUsers;
		

		public UserManager()
		{
			numUsers = 0;

		}

		//testing testing 123


		public User[] getUserList()
		{
			return userList;
		}
	}
}

