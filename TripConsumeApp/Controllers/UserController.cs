using Microsoft.AspNetCore.Mvc;

namespace TripConsumeApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
