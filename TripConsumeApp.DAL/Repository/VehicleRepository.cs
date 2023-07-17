using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripConsumeApp.DAL.Context;
using TripConsumeApp.DAL.IRepository;
using TripConsumeApp.Entities;

namespace TripConsumeApp.DAL.Repository
{
    public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
    {
		private readonly TripConsumeAppContext _context;

        public VehicleRepository(TripConsumeAppContext context) : base(context) 
        {
            _context = context;
        }
        public async Task<IQueryable<Vehicle>> GetByEmail(string email)
        {
			try
			{
                return _context.Vehicles.Include(v => v.User).Where(v => v.User.Email == email); 
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
