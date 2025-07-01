using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prova05.Data;
using Prova05.Models;

namespace Prova05.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/lancamento")]
    public class LancamentoController : ControllerBase
    {
        private readonly ILancamentoRepository _lancamentoRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public LancamentoController(
            ILancamentoRepository lancamentoRepository,
            ICategoriaRepository categoriaRepository,
            IUsuarioRepository usuarioRepository)
        {
            _lancamentoRepository = lancamentoRepository;
            _categoriaRepository = categoriaRepository;
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            string? email = User.Identity?.Name;
            var usuario = _usuarioRepository.BuscarUsuarioPorEmail(email!);
            var lancamentos = _lancamentoRepository.ListarPorUsuario(usuario.Id);
            return Ok(lancamentos);
        }

        [HttpPost("criar")]
        public IActionResult Criar([FromBody] Lancamento lancamento)
        {
            string? email = User.Identity?.Name;
            var usuario = _usuarioRepository.BuscarUsuarioPorEmail(email!);

            var categoria = _categoriaRepository.BuscarCategoriaPorId(lancamento.CategoriaId);
            if (categoria == null)
                return NotFound("Categoria não encontrada");

            lancamento.UsuarioId = usuario.Id;
            lancamento.Categoria = categoria;

            _lancamentoRepository.Criar(lancamento);

            return CreatedAtAction(nameof(BuscarLancamentoPorId), new { lancamentoId = lancamento.Id }, lancamento);
        }

        [HttpGet("buscar/{lancamentoId}")]
        public IActionResult BuscarLancamentoPorId(int lancamentoId)
        {
            var lancamento = _lancamentoRepository.BuscarLancamentoPorId(lancamentoId);
            if (lancamento == null)
                return NotFound();

            string? email = User.Identity?.Name;
            var usuario = _usuarioRepository.BuscarUsuarioPorEmail(email!);
            if (lancamento.UsuarioId != usuario.Id)
                return Forbid();

            return Ok(lancamento);
        }

        [HttpPut("editar/{lancamentoId}")]
        public IActionResult Editar(int lancamentoId, [FromBody] Lancamento lancamentoAtualizado)
        {
            var lancamento = _lancamentoRepository.BuscarLancamentoPorId(lancamentoId);
            if (lancamento == null)
                return NotFound();

            string? email = User.Identity?.Name;
            var usuario = _usuarioRepository.BuscarUsuarioPorEmail(email!);
            if (lancamento.UsuarioId != usuario.Id)
                return Forbid();

            lancamento.Descricao = lancamentoAtualizado.Descricao;
            lancamento.Valor = lancamentoAtualizado.Valor;
            lancamento.Data = lancamentoAtualizado.Data;
            lancamento.CategoriaId = lancamentoAtualizado.CategoriaId;

            _lancamentoRepository.Atualizar(lancamento);

            return Ok(lancamento);
        }

        [HttpDelete("excluir/{lancamentoId}")]
        public IActionResult Excluir(int lancamentoId)
        {
            var lancamento = _lancamentoRepository.BuscarLancamentoPorId(lancamentoId);
            if (lancamento == null)
                return NotFound();

            string? email = User.Identity?.Name;
            var usuario = _usuarioRepository.BuscarUsuarioPorEmail(email!);
            if (lancamento.UsuarioId != usuario.Id)
                return Forbid();

            _lancamentoRepository.Excluir(lancamentoId);
            return NoContent();
        }
    }
}
