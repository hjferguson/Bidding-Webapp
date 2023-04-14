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
            if (!Request.Cookies.ContainsKey("user_credentials"))
            {
                // Redirect to login page or display an error message
                return RedirectToAction("Login", "Account");
            }

            var username = Request.Cookies["user_credentials"];
            var user = _context.Users.FirstOrDefault(u => u.username.Equals(username, StringComparison.Ordinal));

            if (user == null)
            {
                // User not found, handle this case as needed
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
