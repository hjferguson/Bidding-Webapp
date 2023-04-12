using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using bidder.Models;

namespace bidder.Controllers
{
    public class CartController : Controller
    {


        public IActionResult Index()
        {
            return View(_cartItems);
        }

        public IActionResult AddToCart(int productId)
        {
            var product = _products.FirstOrDefault(p => p.Id == productId);

            if (product != null)
            {
                var cartItem = _cartItems.FirstOrDefault(ci => ci.Product.Id == productId);

                if (cartItem != null)
                {
                    cartItem.Quantity++;
                }
                else
                {
                    _cartItems.Add(new CartItem { Product = product, Quantity = 1 });
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            var cartItem = _cartItems.FirstOrDefault(ci => ci.Product.Id == productId);

            if (cartItem != null)
            {
                _cartItems.Remove(cartItem);
            }

            return RedirectToAction("Index");
        }
    }
}
