using Desafio.DTO.Produto;
using Desafio.Model;
using Desafio.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;

        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar([FromBody] ProdutoCreateDto dto)
        {
            var produto = new Produto
            {
                Nome = dto.Nome,
                PrecoCompra = dto.PrecoCompra,
                PrecoVenda = dto.PrecoVenda
            };

            var produtos = await _service.ListarAsync();
            var ultimo = produtos.OrderByDescending(p => p.Id).FirstOrDefault();
            if (ultimo != null)
            {
                produto.Id = ultimo.Id + 1;
            }
            else
            {
                produto.Id = 1;
            }

            var resultado = await _service.CriarAsync(produto);

            return Ok(new ProdutoResponseDto
            {
                Id = resultado.Id,
                Nome = resultado.Nome,
                PrecoVenda = resultado.PrecoVenda
            });
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {
            var produtos = await _service.ListarAsync();

            var resultado = produtos.Select(p => new ProdutoResponseDto
            {
                Id = p.Id,
                Nome = p.Nome,
                PrecoVenda = p.PrecoVenda
            });

            return Ok(resultado);
        }

        [HttpGet("ObterPorId/{id}")]
        public async Task<IActionResult> ObterPorId([FromRoute] long id)
        {
            var produto = await _service.ObterPorIdAsync(id);

            if (produto == null)
                return NotFound();

            return Ok(new ProdutoResponseDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                PrecoVenda = produto.PrecoVenda
            });
        }

        [HttpGet("ObterPorNome")]
        public async Task<IActionResult> ObterPorNome([FromQuery] string nome)
        {
            var produtos = await _service.ObterPorNomeAsync(nome);

            var resultado = produtos.Select(p => new ProdutoResponseDto
            {
                Id = p.Id,
                Nome = p.Nome,
                PrecoVenda = p.PrecoVenda
            });

            return Ok(resultado);
        }

        [HttpGet("Contar")]
        public async Task<IActionResult> Contar()
        {
            var produtos = await _service.ListarAsync();

            if (produtos == null)
                return NotFound();

            return Ok(produtos.Count);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Atualizar(long id, [FromBody] ProdutoUpdateDto dto)
        {
            if (id != dto.Id)
                return BadRequest();

            var produto = new Produto
            {
                Id = dto.Id,
                Nome = dto.Nome,
                PrecoCompra = dto.PrecoCompra,
                PrecoVenda = dto.PrecoVenda
            };

            var atualizado = await _service.AtualizarAsync(produto);

            return Ok(new ProdutoResponseDto
            {
                Id = atualizado.Id,
                Nome = atualizado.Nome,
                PrecoVenda = atualizado.PrecoVenda
            });
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Deletar(long id)
        {
            var deletado = await _service.DeletarAsync(id);

            if (!deletado)
                return NotFound();

            return Ok("Deletado com Sucesso");
        }
    }
}
