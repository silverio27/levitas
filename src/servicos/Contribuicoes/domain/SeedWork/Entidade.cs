using domain.CadastroDeAtividades.ObjetosDeValor;

namespace domain.SeedWork;
public abstract class Entidade
{
    public Guid Id { get; private set; }

    protected Entidade(DateTime criadoEm, Criador criador)
    {
        Id = Guid.NewGuid();
        CriadoEm = criadoEm;
        Criador = criador;
    }

    public DateTime CriadoEm { get; protected set; }
    public Criador Criador { get; protected set; }
    public DateTime? UltimaAlteracao { get; private set; }

    public void AtualizarDataDeAlteracao() => UltimaAlteracao = DateTime.UtcNow;

}
