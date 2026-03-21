using Desafio.AppContext;
using Desafio.Service.Interface;
using Desafio.Service;
using Microsoft.EntityFrameworkCore;
using Desafio.Repository.Interface.Produto;
using Desafio.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("DesafioDB"));

builder.Services.AddScoped<IProdutoService, ProdutoService>();

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
