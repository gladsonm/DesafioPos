namespace Desafio.DTO.Produto
{
    public class ProdutoUpdateDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public decimal PrecoCompra { get; set; }
        public decimal PrecoVenda { get; set; }
    }
}