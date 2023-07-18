using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TripConsumeApp.BLL.ServiceInterfaces;
using TripConsumeApp.Entities;
using TripConsumeApp.Models;

namespace TripConsumeApp.Controllers
{
    public class RefuelingController : Controller
    {
        private readonly IRefuelingService _service;

        public RefuelingController(IRefuelingService service)
        {
            _service = service;
        }

        // GET: RefuelingController
        public async Task<ActionResult> Index(int Id)
        {
            try
            {
                IEnumerable<Refueling> list = await _service.GetAll(Id);
                var resultList = new List<RefuelingVM>();
                var vehicleName = await _service.GetVehicleName(Id);


                foreach (var item in list)
                {
                    var result = new RefuelingVM
                    {
                        Id = item.Id,
                        DateTime = item.DateTime,
                        Amount = item.Amount,
                        Liters = item.Liters,
                        Kilometers = item.Kilometers,
                        KmPerLiter = (item.Kilometers / item.Liters),
                        Liters100Km = (item.Liters / (item.Kilometers / 100)),
                        Comments = item.Comments,
                        VehicleId = item.VehicleId,
                        VehicleName = vehicleName
                    };
                    resultList.Add(result);


                }

                return View(resultList.OrderByDescending(r => r.DateTime));

            }
            catch (Exception)
            {
                return View(new List<RefuelingVM>());
                throw;
            }
        }

        // GET: RefuelingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RefuelingController/Create
        public async Task<ActionResult> NewRefueling(int Id)
        {
            var refueling = new Refueling();
            refueling.VehicleId = Id;

            return View(refueling);
        }

        // POST: RefuelingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewRefueling(Refueling refueling)
        {
            try
            {
                refueling.Id = 0; //TODO: no se porque puta me llega el Id igual que el VehicleId
                await _service.Create(refueling);
                //int Id = refueling.VehicleId;
                return RedirectToAction("Index", "Refueling", new { Id = refueling.VehicleId }); //el tercer parametro era un objeto por eso le pase de esta manera
            }
            catch
            {
                return View();
            }
        }

        // GET: RefuelingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RefuelingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: RefuelingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RefuelingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
