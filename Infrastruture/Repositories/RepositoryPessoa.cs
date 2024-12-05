using Core.IRepositories;
using Core.Models;
using Infrastruture.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.Repositories
{
    public class RepositoryPessoa : IRepositoryPessoa
    {
        private readonly trayprojeto45DbContext _context;
        private readonly DbSet<Pessoa> _dbSet;

        public RepositoryPessoa(trayprojeto45DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Pessoa>();
        }

        public async Task<IEnumerable<Pessoa>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Pessoa> GetByIdAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Pessoa>> FindAsync(Expression<Func<Pessoa, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(Pessoa pessoa)
        {
            await _dbSet.AddAsync(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pessoa pessoa)
        {
            _dbSet.Update(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Pessoa pessoa)
        {
            _dbSet.Remove(pessoa);
            await _context.SaveChangesAsync();
        }
    }
}