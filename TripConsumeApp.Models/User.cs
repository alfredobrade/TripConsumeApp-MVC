using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TripConsumeApp.Entities
{
    public class User 
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; } 


        public ICollection<Vehicle> Vehicles { get; set; }
        //public ICollection<Refueling> Refuelings { get; set; }
        

        
    }
}
