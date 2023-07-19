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
    public class Refueling
    {
        public int Id { get; set; }
        public DateTime? DateTime { get; set; }
        public double? Amount { get; set; }
        public double? Liters { get; set; }
        public double? Kilometers { get; set; }
        public string? Comments { get; set; }

        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }
        //public int UserId { get; set; }
        //public User User { get; set; }

        public int? TripId { get; set; }
        public Trip? Trip { get; set;}
    }
}
