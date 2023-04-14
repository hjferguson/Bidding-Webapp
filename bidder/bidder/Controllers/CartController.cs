using Microsoft.AspNetCore.Mvc;
using bidder.Data;
using bidder.Models;
using System.Diagnostics;
using System.Linq;


namespace bidder.Controllers
{
    public class CartController : Controller
    {

        private SiteContext context;

        public CartController(SiteContext cont)
        {
            context = cont;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
