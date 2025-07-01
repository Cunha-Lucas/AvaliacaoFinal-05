using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prova05.Models;
using Microsoft.EntityFrameworkCore;

namespace Prova05.Data;

public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions options) : base(options) { }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Lancamento> Lancamentos { get; set; }
}