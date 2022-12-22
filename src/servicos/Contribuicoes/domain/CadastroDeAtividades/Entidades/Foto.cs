using domain.IdentidadeEAcesso;
using domain.SeedWork;

namespace domain.CadastroDeAtividades.Entidades;
public class Foto : Entidade
{
    public Foto(string descricao, string sessao, string url, Criador criador)
    :base(criadoEm: DateTime.UtcNow, criador:criador)
    {
        Descricao = descricao;
        Sessao = sessao;
        Url = url;
    }

    public string Descricao { get; private set; }
    public string Sessao { get; private set; }
    public string Url { get; private set; }

}
