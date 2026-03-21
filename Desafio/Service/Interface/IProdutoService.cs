using Desafio.Model;

namespace Desafio.Service.Interface
{
    public interface IProdutoService
    {
        Task<Produto> CriarAsync(Produto produto);
        Task<List<Produto>> ListarAsync();
        Task<Produto?> ObterPorIdAsync(long id);
        Task<List<Produto>?> ObterPorNomeAsync(string nome);
        Task<Produto> AtualizarAsync(Produto produto);
        Task<bool> DeletarAsync(long id);
    }
}
