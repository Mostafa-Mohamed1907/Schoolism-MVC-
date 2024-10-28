using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using School.ViewModel;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace School.Controllers
{
        public class AccountController : Controller
        {
            UserManager<IdentityUser> _userManager;
            SignInManager<IdentityUser> _signInManager;
            public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
            {
                _userManager = userManager;
                _signInManager = signInManager;
            }

            [HttpGet]
            public IActionResult Register()
            {
                return View();
            }
            [HttpPost]
            public async Task<IActionResult> Register(RegisterViewModel newUser)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = newUser.UserName;
                user.PasswordHash = newUser.Password;
                user.Email = newUser.Email;
                IdentityResult result = await _userManager.CreateAsync(user, newUser.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                }
                return View(newUser);
            }

            [HttpGet]
            public IActionResult Login()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Login(LoginViewModel LoginUser)
            {

                if (ModelState.IsValid)
                {
                    IdentityUser user = await _userManager.FindByNameAsync(LoginUser.UserName);
                    if (user != null)
                    {
                        SignInResult result = await _signInManager.PasswordSignInAsync(user, LoginUser.Password, false, false);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Password is Invalid");
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("", "User Name or Password is Invalid");
                    }

                }
                return View();
            }

            public async Task<IActionResult> Logout()
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }

        }
    
}
