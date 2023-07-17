using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TripConsumeApp.Models;
using TripConsumeApp.Models.Data;
using TripConsumeApp.BLL.ServiceInterfaces;

namespace TripConsumeApp.Controllers
{
    public class AccessController : Controller
    {
        private readonly IUserService _service;
        public AccessController(IUserService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var user = new UserVM();
            user.UsersQtity = await _service.UsersQtity();
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserVM user)
        {
            //DBInMemory dbUser = new DBInMemory();

            //var dbUser = await _service.GetByEmail(user.Email);
            var _user = await _service.ValidateUser(user.Email, user.Password);

            if (_user != null)
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, _user.UserName),
                    new Claim(ClaimTypes.Email, _user.Email)
                    //new Claim("Email" , user.Email), //es otra forma que muestra en el video

                };

                //se itera los roles porque tiene varios en este caso
                //foreach (string rol in user.Roles)
                //{
                //    claims.Add(new Claim(ClaimTypes.Role, rol));
                //}

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Vehicle");
            }

            return View(_user);
        }

        public async Task<IActionResult> Exit()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Access");
        }

    }
}
