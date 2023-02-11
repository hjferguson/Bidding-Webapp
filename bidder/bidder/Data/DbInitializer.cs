using System;
namespace bidder.Data
{
	public class DbInitializer
	{
		public DbInitializer(SiteContext context)
		{
			if(context.Database.EnsureCreated())
			{
				return;
			}










        }
	}
}

