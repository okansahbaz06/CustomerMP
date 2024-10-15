using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerMP.Service;
using CustomerMP.UI.Views.Models;
using CustomerMP.Entities.Entities;
using System.Linq;
using CustomerMP.Service.Contracts;
using CustomerMP.DataLayer;

namespace CustomerMP.UI.Controllers
{
    public class LoginController : Controller
    {
        UserService userService = new UserService(new UserRepository());


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var userEntity = userService.GetUserByUsernameAndPassword(username, password);

            if (userEntity != null)
            {
                var userModel = new UserModel
                {
                    Username = userEntity.Username,
                    Password = userEntity.Password,
                    Role = userEntity.Role
                };

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userModel.Username),
                    new Claim(ClaimTypes.Role, userModel.Role)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Customer"); 
            }

            ViewBag.Error = "Geçersiz kullanıcı adı veya şifre.";
            return View();
        }

        public async Task<IActionResult> GuestLogin()
        {
            var guestEntity = userService.GetUserByUsername("guest");

            if (guestEntity != null)
            {
                var guestModel = new UserModel
                {
                    Username = guestEntity.Username,
                    Password = guestEntity.Password,
                    Role = guestEntity.Role
                };

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, guestModel.Username),
                    new Claim(ClaimTypes.Role, guestModel.Role)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Customer");
            }

            ViewBag.Error = "Misafir girişi başarısız.";
            return View("Login");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
