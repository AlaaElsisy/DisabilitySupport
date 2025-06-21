using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilitySupport.DAL.Data;
using DisabilitySupport.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DisabilitySupport.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public ApplicationDbContext _Context { get; }

        public GenericRepository(ApplicationDbContext applicationDbContext) {
            _Context = applicationDbContext;
        }
        public async Task<List<T>> GetAll()
        {
            return await _Context.Set<T>().ToListAsync();
        }
        public async Task<T> GetById(int id)
        {
            return await _Context.Set<T>().FindAsync(id) ;

        }
        public async Task Add(T entity)
        {
            await _Context.Set<T>().AddAsync(entity);
        }
        public Task Update(T entity)
        {
            _Context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }
        public async Task Delete(int id)
        {
            var entityToDelete = await GetById(id);
            if (entityToDelete != null)
            {
                _Context.Set<T>().Remove(entityToDelete);
            }
        }

         
        public async Task Save()
        {
            await _Context.SaveChangesAsync();
        }

    }
}
