﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripConsumeApp.BLL.ServiceInterfaces;
using TripConsumeApp.DAL.IRepository;
using TripConsumeApp.DAL.Repository;
using TripConsumeApp.Entities;

namespace TripConsumeApp.BLL.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _repository;

        public VehicleService(IVehicleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Vehicle> Create(Vehicle vehicle)
        {
            try
            {
                return await _repository.Create(vehicle);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Delete(Vehicle vehicle)
        {
            try
            {
                return await _repository.Delete(vehicle);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Vehicle> Get(Vehicle vehicle)
        {
            try
            {
                return await _repository.Get(v => v.Id == vehicle.Id); //TODO: agregar la logica para que el usuario solo vea su moto

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Vehicle>> GetAll(string email)
        {
            try
            {
                var list = await _repository.GetByEmail(email);
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<Vehicle> Update(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}