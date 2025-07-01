using Prova05.Data;
using Prova05.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Cadastrar(Usuario usuario)
    {
        usuario.SenhaHash = HashSenha(usuario.SenhaHash);
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }

    public Usuario? BuscarUsuarioPorEmail(string email)
    {
        return _context.Usuarios.FirstOrDefault(u => u.Email == email);
    }

    public Usuario? BuscarPorId(int id)
    {
        return _context.Usuarios.FirstOrDefault(u => u.Id == id);
    }

    public bool VerificarCredenciais(string email, string senha)
    {
        var usuario = BuscarUsuarioPorEmail(email);
        if (usuario == null) return false;

        var senhaHash = HashSenha(senha);
        return usuario.SenhaHash == senhaHash;
    }

    private string Senha(string senha)
    {
        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(senha);
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
}
