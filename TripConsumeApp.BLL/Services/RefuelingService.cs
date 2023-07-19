using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripConsumeApp.BLL.ServiceInterfaces;
using TripConsumeApp.DAL.IRepository;
using TripConsumeApp.Entities;

namespace TripConsumeApp.BLL.Services
{
    public class RefuelingService : IRefuelingService
    {
        private readonly IRefuelingRepository _repository;

        public RefuelingService(IRefuelingRepository repository)
        {
            _repository = repository;
        }
        public async Task<Refueling> Create(Refueling refueling)
        {
            try
            {
                refueling.DateTime = DateTime.Now;
                return await _repository.Create(refueling);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Delete(Refueling refueling)
        {
            try
            {
                return await _repository.Delete(refueling);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Refueling> Get(Refueling refueling)
        {
            try
            {
                return await _repository.Get(r => r.Id == refueling.Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Refueling>> GetAll(int vehicleId)
        {
            try
            {
                return await _repository.GetList(r => r.VehicleId == vehicleId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Update(Refueling refueling)
        {
            try
            {
                return await _repository.Edit(refueling);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> GetVehicleName(int vehicleId)
        {
            try
            {
                
                return await _repository.GetVehicleName(vehicleId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
