using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected MyDbContext context;
        public Repository(MyDbContext dbContext)
        {
            context = dbContext;
        }
        public async Task AddAsync(T item)
        {
            await context.Set<T>().AddAsync(item);  
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }
    }
}
