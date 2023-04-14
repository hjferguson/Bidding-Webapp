using bidder.Data;
using bidder.Models;
using Microsoft.AspNetCore.Mvc;

namespace bidder.Controllers
{
    public class FullItemController : Controller
    {
        private SiteContext context;

        public FullItemController(SiteContext cont)
        {
            context = cont;
        }
        public IActionResult Index([FromQuery(Name = "auction_id")] int auction_id)
        {
            Auction? auction = context.Auctions?.Find(auction_id);
            if (auction == null) return RedirectToAction("Index", "Home");
            ViewBag.auction = auction;
            return View();
        }
    }
}
