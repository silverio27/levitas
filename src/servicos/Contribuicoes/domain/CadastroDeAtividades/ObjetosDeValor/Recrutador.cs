using domain.SeedWork;

namespace domain.CadastroDeAtividades.ObjetosDeValor;
public class Recrutador : Usuario
{
    public Recrutador(string idDeUsuario, string nome) : base(idDeUsuario, nome) { }
    public Recrutador(Usuario usuario) : base(usuario.IdDeUsuario, usuario.Nome) { }
}
