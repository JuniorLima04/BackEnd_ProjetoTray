using Core.Models;

namespace Core.IService
{
    public interface ICompraService
    {
        Task<IEnumerable<Compra>> GetAllComprasAsync();
        Task<Compra> GetCompraByIdAsync(string id);
        Task<IEnumerable<Compra>> FindComprasAsync(string produto, string email);
        Task AddCompraAsync(Compra compra);
        Task UpdateCompraAsync(string id, Compra compra);
        Task DeleteCompraAsync(string id);
    }
}