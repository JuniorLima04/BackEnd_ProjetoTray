namespace Core.DTOs
{
    public class CompraDto
    {
        public string Id { get; set; }
        public string Produto { get; set; }
        public decimal Preco { get; set; }
        public string Email { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Complemento { get; set; }

        public CompraDto() { }
    }
}
