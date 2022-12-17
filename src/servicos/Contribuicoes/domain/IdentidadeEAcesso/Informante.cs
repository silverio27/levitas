using domain.SeedWork;

namespace domain.IdentidadeEAcesso;
public class Informante : Usuario, IObjetoDeValor
{
    public Informante(string idDeUsuario, string nome) : base(idDeUsuario, nome){}
    public Informante(Usuario usuario) : base(usuario.IdDeUsuario, usuario.Nome){}
}
