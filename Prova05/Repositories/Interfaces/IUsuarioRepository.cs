using Prova05.Models;

public interface IUsuarioRepository
{
    void Cadastrar(Usuario usuario);
    Usuario? BuscarUsuarioPorEmail(string email);
    Usuario? BuscarPorId(int id);
    bool VerificarCredenciais(string email, string senha);
}
