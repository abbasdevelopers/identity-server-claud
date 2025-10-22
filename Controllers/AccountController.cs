using Microsoft.AspNetCore.Mvc;
using IdentityServer.Models.ViewModels;
using IdentityServer.Services;

namespace IdentityServer.Controllers;

public class AccountController : Controller
{
    private readonly MockDataService _mockData;

    public AccountController(MockDataService mockData)
    {
        _mockData = mockData;
    }

    [HttpGet]
    public IActionResult Login(string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View(new LoginViewModel());
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model, string? returnUrl = null)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        // Mock login - in production, validate credentials
        // For demo, redirect to admin dashboard
        return RedirectToAction("Index", "Admin");
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View(new RegisterViewModel());
    }

    [HttpPost]
    public IActionResult Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        // Mock registration - redirect to login
        return RedirectToAction("Login");
    }

    [HttpGet]
    public IActionResult Mfa()
    {
        return View(new MfaViewModel());
    }

    [HttpPost]
    public IActionResult Mfa(MfaViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        // Mock MFA verification - redirect to dashboard
        return RedirectToAction("Index", "Admin");
    }

    [HttpGet]
    public IActionResult ForgotPassword()
    {
        return View(new ForgotPasswordViewModel());
    }

    [HttpPost]
    public IActionResult ForgotPassword(ForgotPasswordViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        // Mock password reset email sent
        return View(model);
    }

    [HttpGet]
    public IActionResult ResetPassword(string email, string token)
    {
        return View(new ResetPasswordViewModel { Email = email, Token = token });
    }

    [HttpPost]
    public IActionResult ResetPassword(ResetPasswordViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        // Mock password reset - redirect to login
        return RedirectToAction("Login");
    }

    [HttpGet]
    public IActionResult Logout()
    {
        // Mock logout
        return RedirectToAction("Login");
    }

    [HttpGet]
    public IActionResult Security()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Connections()
    {
        return View();
    }
}
