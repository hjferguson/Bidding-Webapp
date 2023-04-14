using Microsoft.AspNetCore.Mvc;
using bidder.Data;
using bidder.Models;
using Microsoft.EntityFrameworkCore;

namespace bidder.Controllers
{
    public class UserController : Controller
    {

        private SiteContext context;

        public UserController(SiteContext cont)
        {
            context = cont;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LeaveReview(int sellerId)
        {
            var seller = context.Users.Include(s => s.reviews).FirstOrDefault(s => s.userID == sellerId);
            if (seller == null)
            {
                return NotFound();
            }

            // validate and process form data
            if (ModelState.IsValid)
            {
                var review = new Review
                {
                    SellerId = sellerId,
                    Rating = Int32.Parse(Request.Form["rating"]),
                    Comment = Request.Form["comment"],
                    DateCreated = DateTime.UtcNow
                };

                seller.reviews.Add(review);
                context.SaveChanges();

                TempData["Message"] = "Thank you for leaving a review!";
                return RedirectToAction("Details", new { id = sellerId });
            }

            return View(seller);
        }

        public List<Review> GetUserReviews(int userID)
        {
            var reviews = context.Review
                .Where(r => r.SellerId == userID)
                .Include(r => r.reviewer)
                .ToList();

            return reviews;
        }



            public IActionResult UserProfile(int userID)
        {
            var user = context.Users
                .Include(u => u.reviews)
                .SingleOrDefault(u => u.userID == userID);

            if (user == null)
            {
                return NotFound();
            }

            var reviews = GetUserReviews(userID);

            var viewModel = new SellerProfileViewModel
            {
                seller = user,
                reviews = reviews
            };

            return View(viewModel);
        }






    }
}
