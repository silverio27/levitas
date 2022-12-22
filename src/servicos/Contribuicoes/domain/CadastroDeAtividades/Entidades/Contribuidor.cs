using domain.CadastroDeAtividades.Enumeraveis;
using domain.IdentidadeEAcesso;
using domain.SeedWork;

namespace domain.CadastroDeAtividades.Entidades;
public class Contribuidor : Entidade
{
    public Contribuidor(string idDeUsuario, string nome, Recrutador recrutador) :
    base(criadoEm: DateTime.UtcNow, criador: new(recrutador.IdDeUsuario, recrutador.Nome))
    {
        IdDeUsuario = idDeUsuario;
        Nome = nome;
        ConsentiuComOsTermos = true;
        Status = StatusDoContribuidor.Ingressou;
        Recrutador = recrutador;
    }

    public Contribuidor(Usuario usuario, Recrutador recrutador) :
    base(criadoEm: DateTime.UtcNow, criador: new(recrutador.IdDeUsuario, recrutador.Nome))
    {
        IdDeUsuario = usuario.IdDeUsuario;
        Nome = usuario.Nome;
        ConsentiuComOsTermos = true;
        Status = StatusDoContribuidor.Ingressou;
        Recrutador = recrutador;
    }

    public string IdDeUsuario { get; private set; }
    public string Nome { get; private set; }
    public bool ConsentiuComOsTermos { get; private set; }
    public Recrutador Recrutador { get; private set; }
    public StatusDoContribuidor Status { get; private set; }
    public void AlterarStatusDoContribuidor(StatusDoContribuidor status) => Status = status;


}
