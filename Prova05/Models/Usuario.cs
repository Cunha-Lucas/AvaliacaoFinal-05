using System.ComponentModel.DataAnnotations;

namespace Prova05.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string senha { get; set; } = string.Empty;
        public List<Lancamento>? Lancamentos { get; set; }
    }
}
