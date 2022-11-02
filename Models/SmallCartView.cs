using System;
namespace Ecommerce.Models
{
    public class SmallCartView
    {
        public SmallCartView()
        {
        }

        public List<CartItem> cartItems { get; set; }

        public decimal grandTotal { get; set; }
    }
}

