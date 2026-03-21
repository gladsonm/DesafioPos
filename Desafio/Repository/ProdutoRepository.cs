using Desafio.AppContext;
using Desafio.Model;
using Desafio.Repository.Interface.Produto;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Produto> CriarAsync(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<List<Produto>> ListarAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto?> ObterPorIdAsync(long id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<List<Produto>?> ObterPorNomeAsync(string nome)
        {
            return await _context.Produtos.Where(x=>x.Nome.ToLower().Contains(nome.ToLower())).ToListAsync();
        }

        public async Task<Produto> AtualizarAsync(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<bool> DeletarAsync(long id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null) return false;

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
