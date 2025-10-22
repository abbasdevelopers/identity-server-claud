using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        // Redirect to login for now
        return RedirectToAction("Login", "Account");
    }

    public IActionResult Error()
    {
        return View();
    }
}
