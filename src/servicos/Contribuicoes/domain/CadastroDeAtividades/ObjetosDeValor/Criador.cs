using domain.SeedWork;

namespace domain.CadastroDeAtividades.ObjetosDeValor;
public class Criador : Usuario
{
    public Criador(string idDeUsuario, string nome) : base(idDeUsuario, nome) { }
    public Criador(Usuario usuario) : base(usuario.IdDeUsuario,usuario.Nome) { }
}
