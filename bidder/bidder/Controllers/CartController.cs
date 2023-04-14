using Microsoft.AspNetCore.Mvc;

namespace bidder.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
