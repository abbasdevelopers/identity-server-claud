using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Controllers;

public class SettingsController : Controller
{
    public IActionResult Index()
    {
        // Redirect to profile for now, or create a dedicated settings page
        return RedirectToAction("Profile", "Users");
    }
}
