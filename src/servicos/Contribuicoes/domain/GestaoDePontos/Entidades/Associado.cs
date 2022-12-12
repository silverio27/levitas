using System.Dynamic;
using domain.CadastroDeAtividades.ObjetosDeValor;
using domain.GestaoDePontos.ObjetosDeValor;
using domain.SeedWork;

namespace domain.GestaoDePontos.Entidades;
public class Associado : RaizDaAgregacao
{
    public string IdDeUsuario { get; private set; }
    public string Nome { get; private set; }
    public int Pontos { get; private set; }
    public MeusPontos MeusPontos { get; private set; }


    public Associado(string idDeUsuario, string nome, Criador criador) : base(criador)
    {
        IdDeUsuario = idDeUsuario;
        Nome = nome;
        Pontos = 0;
        MeusPontos = new(Pontos, 0);
    }
    public Associado(Usuario usuario, Criador criador) : base(criador)
    {
        IdDeUsuario = usuario.IdDeUsuario;
        Nome = usuario.Nome;
        Pontos = 0;
        MeusPontos = new(Pontos, 0);
    }

    public void GanhouPontos(int pontos, string mensagem)
    {
        Pontos += pontos;
        AdicionarAlteracaoAoHistorico(mensagem);
    }

    public void PerderPontos(int pontos, string mensagem)
    {
        Pontos -= pontos;
        AdicionarAlteracaoAoHistorico(mensagem);
    }

    public void AtualizarConversaoDosPontos(ValorDosPontos valorDosPontos)
    {
        MeusPontos = new MeusPontos(Pontos, valorDosPontos.Valor);
    }

}
