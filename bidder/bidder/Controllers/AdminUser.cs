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

    }
}
