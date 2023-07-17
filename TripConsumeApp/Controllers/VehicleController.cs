using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TripConsumeApp.BLL.ServiceInterfaces;
using TripConsumeApp.Entities;

namespace TripConsumeApp.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleService _service;
        //private readonly IUserService _userService;
        private readonly string _userName;
        private readonly string _userEmail;
        public VehicleController(IVehicleService service, IHttpContextAccessor httpContextAccessor)
        {
            _service = service;
            _userName = httpContextAccessor.HttpContext.User.Identity.Name;
            _userEmail = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
            
        }

        // GET: VehicleController
        //public async Task<ActionResult> Index()
        //{
        //    return View();
        //}

        // GET: VehicleController/Details/5
        public async Task<ActionResult> Index()
        {
            IEnumerable<Vehicle> vehicleList = await _service.GetAll(_userEmail);
            return View(vehicleList);
        }

        // GET: VehicleController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: VehicleController/Create
        public async Task<ActionResult> NewVehicle(int userId)
        {
            var vehicle = new Vehicle { UserId = userId };
            //var user = await _service.GetAll(_userEmail);
            //var vehicle = new Vehicle { UserId = user.First().UserId };
            return View(vehicle);
        }

        // POST: VehicleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewVehicle(Vehicle vehicle)
        {
            try
            {
                var user = await _service.GetAll(_userEmail);
                vehicle.UserId = user.First().UserId;


                var result = await _service.Create(vehicle);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(vehicle);
            }
        }

        // GET: VehicleController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: VehicleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: VehicleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
