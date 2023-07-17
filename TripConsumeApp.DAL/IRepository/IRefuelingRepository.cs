using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripConsumeApp.Entities;

namespace TripConsumeApp.DAL.IRepository
{
    public interface IRefuelingRepository : IGenericRepository<Refueling>
    {
        Task<string> GetVehicleName(int vehicleId);
    }
}
