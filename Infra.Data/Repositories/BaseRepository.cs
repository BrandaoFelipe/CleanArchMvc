using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{

    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        private readonly AppDbContext _context;        

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>()
                 .ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _context.Set<T>()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> CreateAsync(T entity)
        {
            _context.Set<T>()
                .Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>()
                .Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            _context.Set<T>()
                .Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
