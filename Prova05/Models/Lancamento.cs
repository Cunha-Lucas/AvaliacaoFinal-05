using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prova05.Models
{
    public class Lancamento
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public bool EhReceita { get; set; } 
        public int CategoriaId { get; set; }
        public int UsuarioId { get; set; }
        public Categoria? Categoria { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
