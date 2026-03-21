using Desafio.Model;
using Microsoft.EntityFrameworkCore;

namespace Desafio.AppContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
