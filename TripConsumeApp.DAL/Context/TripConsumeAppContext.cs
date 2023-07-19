using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripConsumeApp.Entities;

namespace TripConsumeApp.DAL.Context
{
    public class TripConsumeAppContext : DbContext
    {
        
        public TripConsumeAppContext(DbContextOptions<TripConsumeAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<Refueling> Refuelings { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
