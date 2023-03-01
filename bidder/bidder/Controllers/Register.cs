using bidder.Data;
using bidder.Models;
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
        public async Task<IActionResult> Index(bidder.Models.User model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.password != model.passwordConfirm) return View(model);
            context.Users.Add(model);
            context.SaveChanges();
            //start Harlan email code testing
            var emailService = new EmailService("smtp.gmail.com", 587, "harlan.j.ferguson@gmail.com", "ahqovabdazcqxejg"); //Not secure way of coding, but I'm running out of time
            var from = "harlan.j.ferguson@gmail.com";
            var to = model.email;
            var subject = "Please confirm your R.O.J.H Auctions account";
            var body = "test";
            await emailService.SendEmailAsync(from, to, subject, body);
            //end Harlan email code
            return RedirectToAction("Index","Home");
        }
        public Register(SiteContext cont)
        {
            context = cont;
        }
        private SiteContext context;

        
    }
}
