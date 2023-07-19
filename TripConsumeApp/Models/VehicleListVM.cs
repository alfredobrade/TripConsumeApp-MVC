﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using TripConsumeApp.Entities;

namespace TripConsumeApp.Models
{
    public class VehicleListVM
    {
        public int UserId { get; set; }

        public IEnumerable<Vehicle> Vehicles { get; set; }

        

    }
}
