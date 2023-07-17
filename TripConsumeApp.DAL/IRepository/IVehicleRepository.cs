using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripConsumeApp.Entities;

namespace TripConsumeApp.DAL.IRepository
{
    public interface IVehicleRepository : IGenericRepository<Vehicle>
    {
        Task<IQueryable<Vehicle>> GetByEmail(string email);
    }
}
