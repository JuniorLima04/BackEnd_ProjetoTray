using Core.IRepositories;
using Core.Models;
using Infrastruture.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.Repositories
{
    public class RepositoryCompra : IRepositoryCompra
    {
        private readonly trayprojeto45DbContext _context;
        private readonly DbSet<Compra> _dbSet;

        public RepositoryCompra(trayprojeto45DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Compra>();
        }

        public async Task<IEnumerable<Compra>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Compra> GetByIdAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Compra>> FindAsync(Expression<Func<Compra, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(Compra compra)
        {
            await _dbSet.AddAsync(compra);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Compra compra)
        {
            _dbSet.Update(compra);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Compra compra)
        {
            _dbSet.Remove(compra);
            await _context.SaveChangesAsync();
        }
    }
}