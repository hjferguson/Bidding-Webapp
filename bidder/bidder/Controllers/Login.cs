using Microsoft.AspNetCore.Mvc;

namespace bidder.Controllers
{
    public class Login : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
