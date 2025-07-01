using Prova05.Data;
using Prova05.Models;
using System.Collections.Generic;
using System.Linq;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly AppDbContext _context;

    public CategoriaRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Cadastrar(Categoria categoria)
    {
        _context.Categorias.Add(categoria);
        _context.SaveChanges();
    }

    public Categoria? BuscarCategoriaPorId(int id)
    {
        return _context.Categorias.FirstOrDefault(c => c.Id == id);
    }

    public IEnumerable<Categoria> Listar()
    {
        return _context.Categorias.ToList();
    }

    public void Atualizar(Categoria categoria)
    {
        _context.Categorias.Update(categoria);
        _context.SaveChanges();
    }

    public void Excluir(int id)
    {
        var categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);
        if (categoria != null)
        {
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
        }
    }
}
