
using System.Text.Json.Serialization;

using domain.IdentidadeEAcesso;
using domain.SeedWork;

namespace domain.CadastroDeAtividades.Entidades;
public class Foto : Entidade
{
    public Foto(Atividade atividade, string descricao, string sessao, string url, Criador criador)
    :base(criadoEm: DateTime.UtcNow, criador:criador)
    {
        Atividade = atividade;
        Descricao = descricao;
        Sessao = sessao;
        Url = url;
    }

    public int AtividadeId { get; private set; }
    [JsonIgnore]
    public Atividade Atividade { get; private set; }
    public string Descricao { get; private set; }
    public string Sessao { get; private set; }
    public string Url { get; private set; }

}
