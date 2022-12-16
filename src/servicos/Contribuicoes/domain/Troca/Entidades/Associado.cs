using domain.CadastroDeAtividades.ObjetosDeValor;
using domain.CatalogoDeProdutos.Entidades;
using domain.SeedWork;

namespace domain.Troca.Entidades;
public class Associado : RaizDaAgregacao
{
    public Associado(Usuario usuario, Criador criador) : base(criador)
    {
        IdDeUsuario = usuario.IdDeUsuario;
        Nome = usuario.Nome;
        Trocas = new();
    }

    public string IdDeUsuario { get; private set; }
    public string Nome { get; private set; }
    public int Pontos { get; private set; }
    public List<Resgate> Trocas { get; private set; }

    public void AdicionarPontos(int pontos)
    {
        Pontos += pontos;
    }

    public void SubtrairPontos(int pontos)
    {
        Pontos -= pontos;
    }

    public void SolicitarResgate(Produto produto)
    {
        Resgate resgate = new(produto, this, Criador);
        produto.SubtrairEstoque();
        Trocas.Add(resgate);
    }
}
