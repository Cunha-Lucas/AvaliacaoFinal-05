using Prova05.Models;
using System.Collections.Generic;

public interface ICategoriaRepository
{
    void Cadastrar(Categoria categoria);
    Categoria? BuscarCategoriaPorId(int id);
    IEnumerable<Categoria> Listar();
    void Atualizar(Categoria categoria);
    void Excluir(int id);
}
