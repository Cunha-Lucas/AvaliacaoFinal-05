using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prova05.Models;
using Prova05.Data;

namespace Prova05.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/categoria")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            var categorias = _categoriaRepository.Listar();
            return Ok(categorias);
        }

        [HttpGet("buscar/{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var categoria = _categoriaRepository.BuscarCategoriaPorId(id);
            if (categoria == null)
                return NotFound();

            return Ok(categoria);
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromBody] Categoria categoria)
        {
            _categoriaRepository.Cadastrar(categoria);
            return CreatedAtAction(nameof(BuscarPorId), new { id = categoria.Id }, categoria);
        }

        [HttpPut("editar/{id}")]
        public IActionResult Editar(int id, [FromBody] Categoria categoriaAtualizada)
        {
            var categoria = _categoriaRepository.BuscarCategoriaPorId(id);
            if (categoria == null)
                return NotFound();

            categoria.Nome = categoriaAtualizada.Nome;
            _categoriaRepository.Atualizar(categoria);

            return Ok(categoria);
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            var categoria = _categoriaRepository.BuscarCategoriaPorId(id);
            if (categoria == null)
                return NotFound();

            _categoriaRepository.Excluir(id);
            return NoContent();
        }
    }
}
