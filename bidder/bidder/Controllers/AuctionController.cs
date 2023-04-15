using bidder.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace bidder.Controllers
{
    public class AuctionController : Controller
    {
        private readonly SiteContext _context;

        public AuctionController(SiteContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(bidder.Auction model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var username = Request.Cookies["user_credentials"];
            var user = _context.Users?.ToArray().FirstOrDefault(x => x.username.Equals(username, StringComparison.Ordinal));
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var auction = new bidder.Auction
            {
                itemName = model.itemName,
                itemDescription = model.itemDescription,
                startingBid = model.startingBid,
                startTime = model.startTime,
                endTime = model.endTime,
                condition = model.condition,
                type = model.type,
                image = model.image,
                winningBid = model.winningBid,
                currentBid = model.currentBid,
                CreatorId = user.userID // set the creator id to the current user id
            };

            _context.Auctions.Add(auction);
            _context.SaveChanges();

            ViewBag.user = user;

            return RedirectToAction("Index", "Home");
        }

    }
}