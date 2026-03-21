using Desafio.Model;

namespace Desafio.Repository.Interface.Produto
{
    public interface IProdutoRepository
    {
        Task<Desafio.Model.Produto> CriarAsync(Desafio.Model.Produto produto);
        Task<List<Desafio.Model.Produto>> ListarAsync();
        Task<Desafio.Model.Produto?> ObterPorIdAsync(long id);
        Task<List<Desafio.Model.Produto>?> ObterPorNomeAsync(string nome);
        Task<Desafio.Model.Produto> AtualizarAsync(Desafio.Model.Produto produto);
        Task<bool> DeletarAsync(long id);
    }
}
