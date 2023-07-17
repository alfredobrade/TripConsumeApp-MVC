using Microsoft.AspNetCore.Mvc.Rendering;

namespace TripConsumeApp.Models
{
    public class VehicleVM
    {
        //public int Id { get; set; }
        public string VehicleName { get; set; }
        public int? VehicleType { get; set; } //1 auto, 2 moto 
        public double? TankCapacity { get; set; }

        //public int UserId { get; set; }
        //public IEnumerable<SelectListItem> Refuelings { get; set; }
    }
}
