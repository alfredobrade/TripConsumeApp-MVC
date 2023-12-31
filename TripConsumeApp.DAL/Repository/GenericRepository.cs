﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TripConsumeApp.DAL.Context;
using TripConsumeApp.DAL.IRepository;
using Microsoft.EntityFrameworkCore;

namespace TripConsumeApp.DAL.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly TripConsumeAppContext _context;


        public GenericRepository(TripConsumeAppContext context)
        {
            _context = context;
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                TEntity entity = await _context.Set<TEntity>().FirstOrDefaultAsync(filter);

                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IQueryable<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            try
            {
                IQueryable<TEntity> queryEntity = filter == null ?
                    _context.Set<TEntity>() :
                    _context.Set<TEntity>().Where(filter);
                await _context.SaveChangesAsync(); //TODO: esto esta mal

                return queryEntity; //.AsQueryable()
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Edit(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Update(entity); //TODO: tambien le hace _context.Update(entity); para que es el Set<TEntity> ????
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Delete(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> Count()
        {
            try
            {
                return await _context.Set<TEntity>().CountAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
