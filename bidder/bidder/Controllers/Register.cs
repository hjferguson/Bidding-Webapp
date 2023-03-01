using bidder.Data;
using Microsoft.AspNetCore.Mvc;

namespace bidder.Controllers
{
    public class Register : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(bidder.Models.User model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.password != model.passwordConfirm) return View(model);
            context.Users.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        public Register(SiteContext cont)
        {
            context = cont;
        }
        private SiteContext context;
    }
}
