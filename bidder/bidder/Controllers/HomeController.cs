using bidder.Data;
using bidder.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace bidder.Controllers
{
    public class HomeController : Controller
    {
        /*
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        */
        public HomeController(SiteContext cont)
        {
            context = cont;
        }
        private SiteContext context;
        public IActionResult Index(string keyword = "", string category = "", string status = "")
        {
            //Reads if a cookie exists, then finds the user and saves it in the viewbag with name user, entire db object saved
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
                    case "itemName":
                        auctions = auctions.OrderBy(a => a.itemName);
                        break;
                    case "condition":
                        auctions = auctions.OrderBy(a => a.condition);
                        break;
                    case "type":
                        auctions = auctions.OrderBy(a => a.type);
                        break;
                }
            }

            if (!string.IsNullOrEmpty(status))
            {
                switch (status)
                {
                    case "startingBid":
                        auctions = auctions.OrderBy(a => a.startingBid);
                        break;
                    case "currentBid":
                        auctions = auctions.OrderBy(a => a.currentBid);
                        break;
                    case "winningBid":
                        auctions = auctions.OrderByDescending(a => a.currentBid);
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