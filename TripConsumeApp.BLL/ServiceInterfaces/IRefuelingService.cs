using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripConsumeApp.Entities;

namespace TripConsumeApp.BLL.ServiceInterfaces
{
    public interface IRefuelingService
    {
        Task<Refueling> Create(Refueling refueling);
        Task<Refueling> Update(Refueling refueling);
        Task<bool> Delete(Refueling refueling);
        Task<Refueling> Get(Refueling refueling);
        Task<IEnumerable<Refueling>> GetAll(int vehicleId);
        Task<string> GetVehicleName(int VehicleId);
    }
}
