namespace bidder.Models
{
    public class SellerProfileViewModel
    {
        public User seller { get; set; }
        public List<Review>? reviews { get; set; }
        public Review newReview { get; set; }
    }
}