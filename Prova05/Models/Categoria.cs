using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Prova05.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public List<Lancamento>? Lancamentos { get; set; }
    }
}
