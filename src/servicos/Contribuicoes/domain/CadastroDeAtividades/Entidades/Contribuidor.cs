using System.Text.Json.Serialization;
using domain.CadastroDeAtividades.Enumeraveis;
using domain.IdentidadeEAcesso;
using domain.SeedWork;

namespace domain.CadastroDeAtividades.Entidades;
public class Contribuidor : Entidade
{
    public Contribuidor(Atividade atividade, string idDeUsuario, string nome, Recrutador recrutador) :
    base(criadoEm: DateTime.UtcNow, criador: new(recrutador.IdDeUsuario, recrutador.Nome))
    {
        AtividadeId = atividade.Id;
        Atividade = atividade;
        IdDeUsuario = idDeUsuario;
        Nome = nome;
        ConsentiuComOsTermos = true;
        Status = StatusDoContribuidor.Ingressou;
        Recrutador = recrutador;
    }

    public Contribuidor(Atividade atividade, Usuario usuario, Recrutador recrutador) :
    base(criadoEm: DateTime.UtcNow, criador: new(recrutador.IdDeUsuario, recrutador.Nome))
    {
        AtividadeId = atividade.Id;
        Atividade = atividade;
        IdDeUsuario = usuario.IdDeUsuario;
        Nome = usuario.Nome;
        ConsentiuComOsTermos = true;
        Status = StatusDoContribuidor.Ingressou;
        Recrutador = recrutador;
    }

    public Guid AtividadeId { get; private set; }
    [JsonIgnore]
    public Atividade Atividade { get; private set; }
    public string IdDeUsuario { get; private set; }
    public string Nome { get; private set; }
    public bool ConsentiuComOsTermos { get; private set; }
    public Recrutador Recrutador { get; private set; }
    public StatusDoContribuidor Status { get; private set; }
    public void AlterarStatusDoContribuidor(StatusDoContribuidor status) => Status = status;

    
}
