using Microsoft.AspNetCore.Mvc;
using IdentityServer.Services;

namespace IdentityServer.Controllers;

public class UsersController : Controller
{
    private readonly MockDataService _mockData;

    public UsersController(MockDataService mockData)
    {
        _mockData = mockData;
    }

    [HttpGet]
    public IActionResult Profile()
    {
        // Get first user as current user for demo
        var user = _mockData.Users.FirstOrDefault();
        return View(user);
    }
}
