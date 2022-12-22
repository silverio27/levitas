

using domain.IdentidadeEAcesso;

namespace domain.SeedWork;
public abstract class RaizDaAgregacao : Entidade
{
    protected RaizDaAgregacao(Criador criador) : base(DateTime.UtcNow, criador)
    {
        Historico = new();
    }

    public List<Historico> Historico { get; private set; }


    public void AdicionarAlteracaoAoHistorico(string mensagem)
    {
        AtualizarDataDeAlteracao();
        Historico.Add(new(mensagem));
    }
}
