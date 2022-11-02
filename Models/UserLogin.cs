using System;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class UserLogin
    {
        public UserLogin()
        {
        }

        [Required, Display(Name = "Username or email address *")]

        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string  returnURl { get; set; }
    }
}

