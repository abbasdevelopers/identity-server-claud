using Microsoft.AspNetCore.Mvc;
using IdentityServer.Services;

namespace IdentityServer.Controllers;

public class ApiKeysController : Controller
{
    private readonly MockDataService _mockData;

    public ApiKeysController(MockDataService mockData)
    {
        _mockData = mockData;
    }

    public IActionResult Index()
    {
        return View();
    }
}
