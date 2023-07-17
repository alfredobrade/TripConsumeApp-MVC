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
    public class RefuelingRepository : GenericRepository<Refueling>, IRefuelingRepository
    {
		private readonly TripConsumeAppContext _context;

        public RefuelingRepository(TripConsumeAppContext context) : base(context)
        {
            _context = context;
        }
       
        public async Task<string> GetVehicleName(int vehicleId)
        {
			try
			{
                //var refueling = await _context.Refuelings.Include(v => v.Vehicle).Where(v => v.VehicleId == vehicleId).FirstAsync();
                //var name = refueling.Vehicle.VehicleName;
                var result = await _context.Vehicles.Where(v => v.Id == vehicleId).FirstOrDefaultAsync();

                return result.VehicleName;
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
