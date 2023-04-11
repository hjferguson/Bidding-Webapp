using bidder.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace bidder.Controllers
{
    public class Login : Controller
    {
        public Login(SiteContext cont)
        {
            context = cont;
        }
        private SiteContext context;
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            var user = context.Users?.ToArray().FirstOrDefault(x => x.username.Equals(username, StringComparison.Ordinal) && x.password.Equals(password, StringComparison.Ordinal));
            if (user == null)
            {
                return View();
            }


            // Cookie created contains the username passed via the form. This will be used to query the table with the value of this cookie in order to check the user values
            Response.Cookies.Append("user_credentials", username, new CookieOptions()
            {
                Expires= DateTime.UtcNow.AddYears(1),
                Path = "/"
            });

            // this is how to send the user to different view in different controller, this reads the Home folder, and then pull the index, order is stupid
            return RedirectToAction("Index", "Home");
        }
    }
}
