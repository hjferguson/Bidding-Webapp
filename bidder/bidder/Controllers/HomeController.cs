using bidder.Data;
using bidder.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace bidder.Controllers
{
    public class HomeController : Controller
    {
        private SiteContext context;

        public HomeController(SiteContext cont)
        {
            context = cont;
        }

        public IActionResult Index(string keyword = "", string category = "", string status = "", string filter = "")
        {
            if (Request.Cookies.ContainsKey("user_credentials"))
            {
                var username = Request.Cookies["user_credentials"];
                var user = context.Users?.ToArray().FirstOrDefault(x => x.username.Equals(username, StringComparison.Ordinal));
                ViewBag.user = user;
            }

            var auctions = context.Auctions.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                auctions = auctions.Where(a => a.itemName.Contains(keyword) || a.itemDescription.Contains(keyword));
            }

            if (!string.IsNullOrEmpty(category))
            {
                switch (category)
                {
                    case "new":
                        auctions = auctions.Where(a => a.condition == "new");
                        break;
                    case "used":
                        auctions = auctions.Where(a => a.condition == "used");
                        break;
                    case "older":
                        auctions = auctions.Where(a => a.endTime < DateTime.Now);
                        break;
                    case "newer":
                        auctions = auctions.Where(a => a.startTime > DateTime.Now);
                        break;
                    default:
                        break;
                }
            }

            if (!string.IsNullOrEmpty(status))
            {
                switch (status)
                {
                    case "startingBid":
                        auctions = auctions.OrderBy(a => a.startingBid);
                        ViewBag.Status = "Starting Bid";
                        break;
                    case "currentBid":
                        auctions = auctions.OrderBy(a => a.currentBid);
                        ViewBag.Status = "Current Bid";
                        break;
                    case "winningBid":
                        auctions = auctions.OrderByDescending(a => a.currentBid);
                        ViewBag.Status = "Winning Bid";
                        break;
                    default:
                        auctions = auctions.OrderBy(a => a.currentBid);
                        ViewBag.Status = "Current Bid";
                        break;
                }
            }
            else
            {
                auctions = auctions.OrderBy(a => a.currentBid);
                ViewBag.Status = "Current Bid";
            }

            if (!string.IsNullOrEmpty(filter))
            {
                switch (filter)
                {
                    case "active":
                        auctions = auctions.Where(a => DateTime.Now < a.endTime);
                        break;
                    case "closed":
                        auctions = auctions.Where(a => DateTime.Now >= a.endTime);
                        break;
                    default:
                        break;
                }
            }

            return View(auctions.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
