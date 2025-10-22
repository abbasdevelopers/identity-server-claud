using Microsoft.AspNetCore.Mvc;
using IdentityServer.Services;

namespace IdentityServer.Controllers;

public class AdminController : Controller
{
    private readonly MockDataService _mockData;

    public AdminController(MockDataService mockData)
    {
        _mockData = mockData;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Users()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Roles()
    {
        return View(_mockData.Roles);
    }

    [HttpGet]
    public IActionResult Clients()
    {
        return View(_mockData.Clients);
    }

    [HttpGet]
    public IActionResult ApiResources()
    {
        return View(_mockData.ApiResources);
    }

    [HttpGet]
    public IActionResult IdentityResources()
    {
        return View(_mockData.IdentityResources);
    }

    [HttpGet]
    public IActionResult Scopes()
    {
        return View(_mockData.Scopes);
    }

    [HttpGet]
    public IActionResult AuditLogs()
    {
        return View(_mockData.AuditLogs);
    }

    [HttpGet]
    public IActionResult Analytics()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Configuration()
    {
        return View();
    }
}
