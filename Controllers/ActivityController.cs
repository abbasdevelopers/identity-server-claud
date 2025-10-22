using Microsoft.AspNetCore.Mvc;
using IdentityServer.Services;

namespace IdentityServer.Controllers;

public class ActivityController : Controller
{
    private readonly MockDataService _mockData;

    public ActivityController(MockDataService mockData)
    {
        _mockData = mockData;
    }

    public IActionResult Index()
    {
        return View();
    }
}
