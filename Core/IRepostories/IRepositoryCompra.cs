using Core.Models;
using System.Linq.Expressions;

namespace Core.IRepositories
{
    public interface IRepositoryCompra
    {
        Task<IEnumerable<Compra>> GetAllAsync();
        Task<Compra> GetByIdAsync(string id);
        Task<IEnumerable<Compra>> FindAsync(Expression<Func<Compra, bool>> predicate);
        Task AddAsync(Compra compra);
        Task UpdateAsync(Compra compra);
        Task DeleteAsync(Compra Compra);
    }
}