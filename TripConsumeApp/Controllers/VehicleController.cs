using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using TripConsumeApp.BLL.ServiceInterfaces;
using TripConsumeApp.Entities;
using TripConsumeApp.Models;

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
        public async Task<ActionResult> Index(int Id)
        {

            try
            {
                IEnumerable<Vehicle> vehicleList = await _service.GetAll(_userEmail);
                if (vehicleList.IsNullOrEmpty()) vehicleList = await _service.GetList(Id); //userId

                var vehicleVM = new VehicleListVM()
                {
                    Vehicles = vehicleList,
                    UserId = Id
                };


                return View(vehicleVM);

            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: VehicleController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: VehicleController/Create
        public async Task<ActionResult> NewVehicle(int Id)
        {
            var vehicle = new Vehicle { UserId = Id };
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
                //var user = await _service.GetAll(_userEmail);
                //vehicle.UserId = user.First().UserId;

                vehicle.Id = 0; //Id le pone el mismo valor que UserId
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
