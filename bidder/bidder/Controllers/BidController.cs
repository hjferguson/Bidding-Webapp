using bidder.Data;
using bidder.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace bidder.Controllers
{
    public class BidController : Controller
    {
        private readonly SiteContext _context;

        public BidController(SiteContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult PlaceBid(int auctionId, double amount)
        {
            //trying to follow other controllers where a viewbag is made from the cookie...
            
            if (Request.Cookies.ContainsKey("user_credentials"))
            {
                var username = Request.Cookies["user_credentials"];
                var myuser = _context.Users?.ToArray().FirstOrDefault(x => x.username.Equals(username, StringComparison.Ordinal));
                ViewBag.user = myuser;
            }

            var user = ViewBag.user as User;

            if (user == null)
            {
                // Redirect to login page or display an error message
                return RedirectToAction("Login", "Account");
            }

            var auction = _context.Auctions.FirstOrDefault(a => a.Id == auctionId);

            if (auction == null)
            {
                // Auction not found, handle this case as needed
                return RedirectToAction("Index", "Home");
            }

            if (amount <= auction.currentBid)
            {
                // The bid amount is not greater than the current bid, handle this case as needed
                return RedirectToAction("Index", "Home");
            }

            var bid = new Bid
            {
                AuctionID = auctionId,
                UserID = user.userID,
                Amount = amount
            };

            auction.currentBid = amount;

            _context.Bids.Add(bid);
            _context.SaveChanges();

            // Redirect to the auction details page or another appropriate page
            return RedirectToAction("Index", "Home");
        }
    }
}
