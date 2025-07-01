using Prova05.Models;
using System.Collections.Generic;

public interface ILancamentoRepository
{
    void Criar(Lancamento lancamento);
    Lancamento? BuscarLancamentoPorId(int id);
    IEnumerable<Lancamento> ListarPorUsuario(int usuarioId);
    void Atualizar(Lancamento lancamento);
    void Excluir(int id);
}
