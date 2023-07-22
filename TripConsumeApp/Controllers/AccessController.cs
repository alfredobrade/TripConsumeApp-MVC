using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TripConsumeApp.Models;
using TripConsumeApp.Models.Data;
using TripConsumeApp.BLL.ServiceInterfaces;
using Azure.Identity;

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
            var userVM = new UserVM();
            userVM.UsersQtity = await _service.UsersQtity();
            return View(userVM);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserVM userVM)
        {
            //DBInMemory dbUser = new DBInMemory();
            //var dbUser = await _service.GetByEmail(user.Email);
            var _user = await _service.ValidateUser(userVM.Email, userVM.Password);

            if (_user != null)
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, _user.UserName),
                    new Claim(ClaimTypes.Email, _user.Email)
                    //new Claim("Email" , user.Email), //asi se pone cuando es un nombre adicional que se agrega 

                };

                //se itera los roles porque tiene varios en este caso
                //foreach (string rol in user.Roles)
                //{
                //    claims.Add(new Claim(ClaimTypes.Role, rol));
                //}

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Vehicle", new { UserId = _user.Id});
            }

            userVM.Email = userVM.Email + " es Incorrecto o no existe";
            userVM.UsersQtity = await _service.UsersQtity();
            return View(userVM); //TODO: corregir esto
        }

        public async Task<IActionResult> Exit()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Access");
        }


    }
}
