using Core.Models;

namespace Core.IService
{
    public interface IPessoaService
    {
        Task<IEnumerable<Pessoa>> GetAllPessoasAsync();
        Task<Pessoa> GetPessoaByIdAsync(string id);
        Task<IEnumerable<Pessoa>> FindPessoasAsync(string nome, string email);
        Task AddPessoaAsync(Pessoa pessoa);
        Task UpdatePessoaAsync(string id, Pessoa pessoa);
        Task DeletePessoaAsync(string id);
    }
}