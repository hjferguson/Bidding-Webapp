using bidder.Data;
using bidder.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
namespace bidder.Controllers

{
    public class AdminItem : Controller
    {
        public AdminItem(SiteContext cont)
        {
            context = cont;
        }
        private SiteContext context;
        public IActionResult Index()
        {
            var auctions = context.Auctions;
            return View(auctions);
        }

    }
}