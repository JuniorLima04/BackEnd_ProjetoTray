using Core.IRepositories;
using Core.IService;
using Core.Models;

namespace Application.Service
{
    public class CompraService : ICompraService
    {
        private readonly IRepositoryCompra _repositoryCompra;

        public CompraService(IRepositoryCompra repositoryCompra)
        {
            _repositoryCompra = repositoryCompra;
        }

        public async Task<IEnumerable<Compra>> GetAllComprasAsync()
        {
            return await _repositoryCompra.GetAllAsync();
        }

        public async Task<Compra> GetCompraByIdAsync(string id)
        {
            return await _repositoryCompra.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Compra>> FindComprasAsync(string produto, string email)
        {
            if (!string.IsNullOrEmpty(produto) && !string.IsNullOrEmpty(email))
            {
                return await _repositoryCompra.FindAsync(c => c.Produto.Contains(produto) && c.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            }
            else if (!string.IsNullOrEmpty(produto))
            {
                return await _repositoryCompra.FindAsync(c => c.Produto.Contains(produto));
            }
            else if (!string.IsNullOrEmpty(email))
            {
                return await _repositoryCompra.FindAsync(c => c.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            }
            return await _repositoryCompra.GetAllAsync();
        }

        public async Task AddCompraAsync(Compra compra)
        {
            await _repositoryCompra.AddAsync(compra);
        }

        public async Task UpdateCompraAsync(string id, Compra compra)
        {
            var compraExistente = await _repositoryCompra.GetByIdAsync(id);
            if (compraExistente != null)
            {
                compra.Id = compraExistente.Id;
                await _repositoryCompra.UpdateAsync(compra);
            }
        }

        public async Task DeleteCompraAsync(string id)
        {
            var compra = await _repositoryCompra.GetByIdAsync(id);
            if (compra != null)
            {
                await _repositoryCompra.DeleteAsync(compra);
            }
        }
    }
}