using Microsoft.AspNetCore.Mvc;
using IdentityServer.Services;

namespace IdentityServer.Controllers;

public class DashboardController : Controller
{
    private readonly MockDataService _mockData;

    public DashboardController(MockDataService mockData)
    {
        _mockData = mockData;
    }

    public IActionResult Index()
    {
        return View();
    }
}
