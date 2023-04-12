using bidder.Data;
using bidder.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
namespace bidder.Controllers

{
    public class AdminUser : Controller
    {
        public AdminUser(SiteContext cont)
        {
            context = cont;
        }
        private SiteContext context;
        public IActionResult Index()
        {
            var users = context.Users;
            return View(users);
        }

        [HttpPost("AdminUserUpdate")]
        public IActionResult AdminUserUpdate(int aid)
        {
            User? user = context.Users?.Find(aid);
            if (user == null) return RedirectToAction("Index");

            return View("AdminUserUpdate", user);
        }

        [HttpPost("AdminUserUpdateProcess")]
        public IActionResult AdminUserUpdateProcess(User user)
        {
            //User? user = context.Users?.Find(user);
            //if (user == null) return RedirectToAction("Index");
            if (!ModelState.IsValid) return View("AdminUserUpdate", user);

            context.Users?.Update(user);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost("AdminUserDelete")]
        public IActionResult AdminUserDelete(int aid)
        {
            User? user = context.Users?.Find(aid);
            if (user == null) return RedirectToAction("Index");

            context.Users?.Remove(user);
            context.SaveChanges();
            return RedirectToAction("Index");
        }   
    }
}
