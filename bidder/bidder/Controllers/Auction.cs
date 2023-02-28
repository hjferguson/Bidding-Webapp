using Microsoft.AspNetCore.Mvc;

namespace bidder.Controllers
{
    public class Auction : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
