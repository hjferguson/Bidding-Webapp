using bidder.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace bidder.Controllers
{
    public class AuctionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(bidder.Auction model)
        {
            //Request.
            
            if (!ModelState.IsValid) return View(model);
            context.Auctions?.Add(model);
            context.SaveChanges();
            if (Request.Cookies.ContainsKey("user_credentials"))
            {
                var username = Request.Cookies["user_credentials"];
                var user = context.Users?.ToArray().FirstOrDefault(x => x.username.Equals(username, StringComparison.Ordinal));
                ViewBag.user = user;
            }
            return RedirectToAction("Index","Home");
        }
        public AuctionController(SiteContext cont)
        {
            context = cont;
        }
        private SiteContext context;
    }
}
