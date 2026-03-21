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
        public async Task<IActionResult> Criar([FromBody] Produto produto)
        {
            if (produto.Id < 1)
            {
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
            }
            var registro = await _service.ObterPorIdAsync(produto.Id);
            if (registro != null) {
                throw new ArgumentException("Produto já Cadastrado");
            }

            var resultado = await _service.CriarAsync(produto);
            return CreatedAtAction(nameof(ObterPorId), new { id = resultado.Id }, resultado);
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {
            var lista = await _service.ListarAsync();
            return Ok(lista);
        }

        [HttpGet("ObterPorId/{id}")]
        public async Task<IActionResult> ObterPorId([FromRoute] int id)
        {
            var produto = await _service.ObterPorIdAsync(id);

            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        [HttpGet("ObterPorNome")]
        public async Task<IActionResult> ObterPorNome([FromQuery] string nome)
        {
            var produto = await _service.ObterPorNomeAsync(nome);

            return Ok(produto);
        }

        [HttpGet("Contar")]
        public async Task<IActionResult> Contar([FromRoute] int id)
        {
            var produtos = await _service.ListarAsync();

            if (produtos == null)
                return NotFound();

            return Ok(produtos.Count);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Produto produto)
        {
            if (id != produto.Id)
                return BadRequest("ID da rota diferente do modelo");

            var existente = await _service.ObterPorIdAsync(id);
            if (existente == null)
                return NotFound();

            var atualizado = await _service.AtualizarAsync(produto);
            return Ok(atualizado);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var deletado = await _service.DeletarAsync(id);

            if (!deletado)
                return NotFound();

            return Ok("Deletado com Sucesso");
        }
    }
}
