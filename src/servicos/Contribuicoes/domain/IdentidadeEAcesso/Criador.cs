using domain.SeedWork;

namespace domain.IdentidadeEAcesso;
public class Criador : Usuario, IObjetoDeValor
{
    public Criador(string idDeUsuario, string nome) : base(idDeUsuario, nome) { }
    public Criador(Usuario usuario) : base(usuario.IdDeUsuario,usuario.Nome) { }
}
