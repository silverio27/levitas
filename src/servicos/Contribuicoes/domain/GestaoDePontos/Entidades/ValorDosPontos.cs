
using domain.IdentidadeEAcesso;
using domain.SeedWork;

namespace domain.GestaoDePontos.Entidades;
public class ValorDosPontos : Entidade
{
    public double Valor { get; private set; }
    public bool Vigente { get; private set; }
    public ValorDosPontos(Criador criador, double valor) : base(criadoEm: DateTime.UtcNow, criador)
    {
        Vigente = true;
        Valor= valor;
    }
}
