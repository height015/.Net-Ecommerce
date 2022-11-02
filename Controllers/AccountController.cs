using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers;

public class AccountController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}