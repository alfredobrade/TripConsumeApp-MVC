using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
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
        public async Task<ActionResult> Index(int UserId)
        {

            try
            {
                var vehicleList = await _service.GetAll(_userEmail);
                if (vehicleList.IsNullOrEmpty()) vehicleList = await _service.GetList(UserId);

                foreach (var item in vehicleList)
                {
                    item.AverageConsume = await _service.AverageConsume(item.Id);
                    item.AverageAutonomy = item.TankCapacity * item.AverageConsume;
                }
                var vehicleVM = new VehicleListVM()
                {
                    Vehicles = vehicleList,
                    UserId = UserId
                };

                return View(vehicleVM);

            }
            catch (Exception)
            {

                throw;
            }
        }

  
        // GET: VehicleController/Create
        public async Task<ActionResult> NewVehicle(int UserId)
        {
            var vehicle = new Vehicle { UserId = UserId };
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

                return RedirectToAction("Index", "Vehicle", new { UserId = vehicle.UserId });
            }
            catch
            {
                return View(vehicle);
            }
        }

        // GET: VehicleController/Edit/5
        public async Task<ActionResult> Edit(int VehicleId)
        {
            try
            {
                var vehicle = await _service.Get(VehicleId);
                return View(vehicle);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: VehicleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Vehicle vehicle)
        {
            try
            {
                if (vehicle != null) await _service.Update(vehicle);

                return RedirectToAction("Index", "Vehicle", new { UserId = vehicle.UserId });
            }
            catch
            {
                return View(vehicle);
            }
        }

        // GET: VehicleController/Delete/5
        public async Task<ActionResult> Delete(int VehicleId)
        {
            try
            {
                var vehicle = await _service.Get(VehicleId);
                return View(vehicle);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: VehicleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Vehicle vehicle)
        {
            try
            {

                if (vehicle.Id != 0) await _service.Delete(vehicle);

                return RedirectToAction("Index", "Vehicle", new { UserId = vehicle.UserId });
            }
            catch
            {
                return View(vehicle);

            }
        }
    }
}
