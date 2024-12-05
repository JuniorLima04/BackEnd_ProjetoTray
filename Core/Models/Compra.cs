using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class Compra
    {
        public string Id { get; set; }
        public string Produto { get; set; }
        public decimal Preco { get; set; }
        public string Email { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Complemento { get; set; }

        public Compra() { }

        public Compra(string produto, decimal preco, string email, string cidade, string estado, string complemento)
        {
            Produto = produto;
            Preco = preco;
            Email = email;
            Cidade = cidade;
            Estado = estado;
            Complemento = complemento;
        }
    }
}