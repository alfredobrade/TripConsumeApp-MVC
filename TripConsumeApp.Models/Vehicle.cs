using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TripConsumeApp.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string VehicleName { get; set; }
        public int? VehicleType { get; set; } //1 auto, 2 moto 
        public double? TankCapacity { get; set; }
        public int? Odometer {get; set;  }

        //no se guarda en base de datos
        public double? AverageConsume { get; set; }
        public double? AverageAutonomy { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Refueling>? Refuelings { get; set; }

        public string Saludar()
        {
            return "hola";
        }
    }
}
