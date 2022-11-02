using System;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Infrastructure
{
    public class SmallCartViewComponent : ViewComponent
    {
        public SmallCartViewComponent()
        {
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            SmallCartView smallCartView = new SmallCartView
            {
                cartItems = cart,
                grandTotal = cart.Sum(x=>x.Price * x.Quantity)
            };

          
            return View(smallCartView);
        } 
    }
}

