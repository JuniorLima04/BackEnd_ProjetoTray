using Core.IRepositories;
using Core.IService;
using Core.Models;

namespace Application.Service
{
    public class PessoaService : IPessoaService
    {
        private readonly IRepositoryPessoa _repositoryPessoa;

        public PessoaService(IRepositoryPessoa repositoryPessoa)
        {
            _repositoryPessoa = repositoryPessoa;
        }

        public async Task<IEnumerable<Pessoa>> GetAllPessoasAsync()
        {
            return await _repositoryPessoa.GetAllAsync();
        }

        public async Task<Pessoa> GetPessoaByIdAsync(string id)
        {
            return await _repositoryPessoa.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Pessoa>> FindPessoasAsync(string nome, string email)
        {
            if (!string.IsNullOrEmpty(nome) && !string.IsNullOrEmpty(email))
            {
                return await _repositoryPessoa.FindAsync(p => p.Nome.Contains(nome) && p.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            }
            else if (!string.IsNullOrEmpty(nome))
            {
                return await _repositoryPessoa.FindAsync(p => p.Nome.Contains(nome));
            }
            else if (!string.IsNullOrEmpty(email))
            {
                return await _repositoryPessoa.FindAsync(p => p.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            }
            return await _repositoryPessoa.GetAllAsync();
        }

        public async Task AddPessoaAsync(Pessoa pessoa)
        {
            await _repositoryPessoa.AddAsync(pessoa);
        }

        public async Task UpdatePessoaAsync(string id, Pessoa pessoa)
        {
            var pessoaExistente = await _repositoryPessoa.GetByIdAsync(id);
            if (pessoaExistente != null)
            {
                pessoa.Id = pessoaExistente.Id;
                await _repositoryPessoa.UpdateAsync(pessoa);
            }
        }

        public async Task DeletePessoaAsync(string id)
        {
            var pessoa = await _repositoryPessoa.GetByIdAsync(id);
            if (pessoa != null)
            {
                await _repositoryPessoa.DeleteAsync(pessoa);
            }
        }
    }
}