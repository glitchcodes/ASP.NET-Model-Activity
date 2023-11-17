using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TamposModelActivity.Data;
using TamposModelActivity.ViewModels;

namespace TamposModelActivity.Controllers;

public class AccountController : Controller
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;

    public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel data)
    {
        var result = await _signInManager.PasswordSignInAsync(data.UserName, data.Password, data.RememberMe, false);

        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Instructor");
        }
        else
        {
            ModelState.AddModelError("", "Incorrect username/password");
        }

        return View(data);
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel data)
    {
        if (ModelState.IsValid)
        {
            var user = new User
            {
                UserName = data.UserName,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, data.Password);
            
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Instructor");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
        }

        return View(data);
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Instructor");
    }
}