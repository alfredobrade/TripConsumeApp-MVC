using Microsoft.AspNetCore.Mvc;
using TripConsumeApp.BLL.ServiceInterfaces;
using TripConsumeApp.Entities;
using TripConsumeApp.Models;

namespace TripConsumeApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        public IActionResult Index(UserVM userVM)
        {
            
            var Id = userVM.Id;
            
            return View(userVM);
        }

        // GET: VehicleController/Create
        public async Task<ActionResult> NewUser()
        {

            return View();
        }

        // POST: VehicleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewUser(UserVM userVM)
        {
            try
            {
                var user = new User()
                {
                    Email = userVM.Email,
                    UserName = userVM.Name,
                    Password = userVM.Password
                };



                user = await _service.Create(user);
                userVM.Id = user.Id;
                return RedirectToAction("Index", "User",  userVM);
            }
            catch
            {
                return View();
            }
        }

    }
}
