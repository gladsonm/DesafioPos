using Desafio.Model;
using Desafio.Repository.Interface.Produto;
using Desafio.Service.Interface;

namespace Desafio.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Produto> CriarAsync(Produto produto)
        {
            // ponto ideal para regra de negócio
            return await _repository.CriarAsync(produto);
        }

        public async Task<List<Produto>> ListarAsync()
        {
            return await _repository.ListarAsync();
        }

        public async Task<Produto?> ObterPorIdAsync(long id)
        {
            return await _repository.ObterPorIdAsync(id);
        }

        public async Task<List<Produto>?> ObterPorNomeAsync(string nome)
        {
            return await _repository.ObterPorNomeAsync(nome);
        }

        public async Task<Produto> AtualizarAsync(Produto produto)
        {
            return await _repository.AtualizarAsync(produto);
        }

        public async Task<bool> DeletarAsync(long id)
        {
            return await _repository.DeletarAsync(id);
        }
    }
}
