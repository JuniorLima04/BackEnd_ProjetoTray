using Core.Models;
using System.Linq.Expressions;

namespace Core.IRepositories
{
    public interface IRepositoryPessoa
    {
        Task<IEnumerable<Pessoa>> GetAllAsync();
        Task<Pessoa> GetByIdAsync(string id);
        Task<IEnumerable<Pessoa>> FindAsync(Expression<Func<Pessoa, bool>> predicate);
        Task AddAsync(Pessoa pessoa);
        Task UpdateAsync(Pessoa pessoa);
        Task DeleteAsync(Pessoa pessoa);
    }
}