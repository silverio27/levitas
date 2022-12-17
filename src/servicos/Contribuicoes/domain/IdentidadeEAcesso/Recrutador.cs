using domain.SeedWork;

namespace domain.IdentidadeEAcesso;
public class Recrutador : Usuario, IObjetoDeValor
{
    public Recrutador(string idDeUsuario, string nome) : base(idDeUsuario, nome) { }
    public Recrutador(Usuario usuario) : base(usuario.IdDeUsuario, usuario.Nome) { }
}
