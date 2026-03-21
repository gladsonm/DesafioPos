using Desafio.AppContext;
using Desafio.Service.Interface;
using Desafio.Service;
using Microsoft.EntityFrameworkCore;
using Desafio.Repository.Interface.Produto;
using Desafio.Repository;
using Desafio.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("DesafioDB"));

builder.Services.AddScoped<IProdutoService, ProdutoService>();

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = "API Desafio - Gladson Magalhães",
        Version = "v1",
        Description = "API REST para gerenciamento de produtos (Arquitetura de Software)"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();

app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();


using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!context.Produtos.Any())
    {
        context.Produtos.AddRange(
            new Produto
            {
                Id = 1,
                Nome = "Notebook",
                PrecoCompra = 2500,
                PrecoVenda = 3500
            },
            new Produto
            {
                Id = 2,
                Nome = "Mouse Gamer",
                PrecoCompra = 50,
                PrecoVenda = 120
            },
            new Produto
            {
                Id = 3,
                Nome = "Teclado Mecânico",
                PrecoCompra = 200,
                PrecoVenda = 400
            }
        );

        context.SaveChanges();
    }
}

app.Run();
