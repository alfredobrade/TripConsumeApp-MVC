using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripConsumeApp.Entities;

namespace TripConsumeApp.BLL.ServiceInterfaces
{
    public interface IVehicleService
    {
        Task<Vehicle> Create(Vehicle vehicle);
        Task<Vehicle> Update(Vehicle vehicle);
        Task<bool> Delete(Vehicle vehicle);
        Task<Vehicle> Get(Vehicle vehicle);
        Task<IEnumerable<Vehicle>> GetAll(string email);
        

    }
}
