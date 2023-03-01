using bidder.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace bidder.Controllers
{
    public class Auction : Controller
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
            context.Auctions.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        public Auction(SiteContext cont)
        {
            context = cont;
        }
        private SiteContext context;

    }
}
