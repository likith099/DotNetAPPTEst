using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TestTwo.Controllers
{
    public class AccountController : Controller
    {
        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "/")
        {
            return Challenge(new AuthenticationProperties { RedirectUri = returnUrl }, OpenIdConnectDefaults.AuthenticationScheme);
        }

        [HttpGet]
        public IActionResult Register(string returnUrl = "/")
        {
            // For Microsoft sign up, use the same as login
            return Challenge(new AuthenticationProperties { RedirectUri = returnUrl }, OpenIdConnectDefaults.AuthenticationScheme);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            // Sign out locally (delete cookie)
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme, new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(-1),
                IsPersistent = false,
                AllowRefresh = false
            });

            // Sign out from Microsoft (remote)
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme, new AuthenticationProperties
            {
                RedirectUri = Url.Action("Index", "Home", null, Request.Scheme)
            });
            return new EmptyResult(); // Response will be handled by OIDC middleware
        }
    }
}
