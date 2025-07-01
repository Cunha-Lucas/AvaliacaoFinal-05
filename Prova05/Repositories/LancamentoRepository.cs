using Prova05.Data;
using Prova05.Models;
using System.Collections.Generic;
using System.Linq;

public class LancamentoRepository : ILancamentoRepository
{
    private readonly AppDbContext _context;

    public LancamentoRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Criar(Lancamento lancamento)
    {
        _context.Lancamentos.Add(lancamento);
        _context.SaveChanges();
    }

    public Lancamento? BuscarLancamentoPorId(int id)
    {
        return _context.Lancamentos
            .FirstOrDefault(l => l.Id == id);
    }

    public IEnumerable<Lancamento> ListarPorUsuario(int usuarioId)
    {
        return _context.Lancamentos
            .Where(l => l.UsuarioId == usuarioId)
            .ToList();
    }

    public void Atualizar(Lancamento lancamento)
    {
        _context.Lancamentos.Update(lancamento);
        _context.SaveChanges();
    }

    public void Excluir(int id)
    {
        var lancamento = _context.Lancamentos.FirstOrDefault(l => l.Id == id);
        if (lancamento != null)
        {
            _context.Lancamentos.Remove(lancamento);
            _context.SaveChanges();
        }
    }
}
