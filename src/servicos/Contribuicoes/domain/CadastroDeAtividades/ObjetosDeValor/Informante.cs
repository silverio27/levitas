using domain.SeedWork;

namespace domain.CadastroDeAtividades.ObjetosDeValor;
public class Informante : Usuario
{
    public Informante(string idDeUsuario, string nome) : base(idDeUsuario, nome){}
    public Informante(Usuario usuario) : base(usuario.IdDeUsuario, usuario.Nome){}
}
