using System;
namespace Ecommerce.Models
{
    public class CartItemView
    {
        public CartItemView()
        {
        }

        public List<CartItem> cartItems { get; set; }

        public decimal  grandTotal { get; set; }


    }
}

