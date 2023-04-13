using bidder.Data;
using bidder.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
namespace bidder.Controllers

{
    public class AdminItemController : Controller
    {
        public AdminItemController(SiteContext cont)
        {
            context = cont;
        }
        private SiteContext context;
        public IActionResult Index()
        {
            var auctions = context.Auctions;
            return View(auctions);
        }
        [HttpPost("AdminItemUpdate")]
        public IActionResult AdminItemUpdate(int aid)
        {
            var auction = context.Auctions?.Find(aid);
            if (auction == null) return RedirectToAction("Index");

            return View("AdminItemUpdate", auction);
        }

        [HttpPost("AdminItemUpdateProcess")]
        public IActionResult AdminItemUpdateProcess(bidder.Auction item)
        {
            if (!ModelState.IsValid) return View("AdminItemUpdate", item);

            context.Auctions?.Update(item);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost("AdminItemDelete")]
        public IActionResult AdminItemDelete(int aid)
        {
            var item = context.Auctions?.Find(aid);
            if (item == null) return RedirectToAction("Index");

            context.Auctions?.Remove(item);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}