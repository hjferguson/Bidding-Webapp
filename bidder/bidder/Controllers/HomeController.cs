using bidder.Data;
using bidder.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
        public IActionResult Index()
        {
            //Reads if a cookie exists, then finds the user and saves it in the viewbag with name user, entire db object saved
            if (Request.Cookies.ContainsKey("user_credentials"))
            {
                var username = Request.Cookies["user_credentials"];
                var user = context.Users?.ToArray().FirstOrDefault(x => x.username.Equals(username, StringComparison.Ordinal));
                ViewBag.user = user;
            }

            var auctions = context.Auctions;
            return View(auctions);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}