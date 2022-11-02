using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Ecommerce.Infrastructure;
using Ecommerce.Service;


namespace Ecommerce.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;


        public CartController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();


            CartItemView cartView = new CartItemView {
                cartItems = cart,
                grandTotal = cart.Sum(x => x.Price * x.Quantity)
            };

            return View(cartView);
        }


        public async Task<IActionResult> Add(int id)
        {
            Product product = await _productService.GetProductByIdWithImagesIncludedsAsync(id);

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartItem cartItem = cart.Where(x => x.ProductId == id).FirstOrDefault();

            if (cartItem == null)
            {
                cart.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Image = product.productImages.FirstOrDefault(x=>x.ProductId == product.Id).image,
                    Price = product.Price,
                    Quantity = 1
   
                });
            }
            else
            {
                cartItem.Quantity += 1;
            }

            HttpContext.Session.SetJson("Cart", cart);
            return RedirectToAction("Index");
        }


        public  IActionResult Decrease(int id)
        {
         

            List<CartItem> cart =  HttpContext.Session.GetJson<List<CartItem>>("Cart");

            CartItem cartItem = cart.Where(x => x.ProductId == id).FirstOrDefault();

            if (cartItem.Quantity > 1)
            {

                --cartItem.Quantity;

               
            }
            else
            {
                cart.RemoveAll(x => x.ProductId == id);
            }

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

          
            return RedirectToAction("Index");
        }




        public IActionResult Remove(int id)
        {


            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            cart.RemoveAll(x => x.ProductId == id);
            

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }


            return RedirectToAction("Index");
        }



        public IActionResult Clear()
        {

           HttpContext.Session.Remove("Cart");

            return RedirectToAction("Index");

        }

    }
}

