using System;
using Microsoft.EntityFrameworkCore;
using bidder.Models;
namespace bidder
{
	public class UserContext : DbContext
	{
		public UserContext(DbContextOptions<UserContext> options) : base(options){}


		public DbSet<User> Users { get; set; }
		
	}
}

