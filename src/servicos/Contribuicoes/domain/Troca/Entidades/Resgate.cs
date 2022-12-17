
using domain.CatalogoDeProdutos.Entidades;
using domain.CatalogoDeProdutos.Enumeraveis;
using domain.IdentidadeEAcesso;
using domain.SeedWork;
using domain.Troca.Excepitions;

namespace domain.Troca.Entidades;
public class Resgate : Entidade
{
    public Guid IdProduto { get; private set; }
    public Produto Produto { get; set; }
    public Guid IdAssociado { get; private set; }
    public Associado Associado { get; private set; }
    public Resgate(Produto produto, Associado associado, Criador criador) : base(DateTime.UtcNow, criador)
    {
        if (produto.Status == StatusDoProduto.Bloqueado ||
           produto.Status == StatusDoProduto.Acabou)
            throw new TrocaExceptions("O produto não está disponível para troca.");
        Produto = produto;

        if (associado.Pontos < produto.Pontos)
            throw new TrocaExceptions("O associado não possui pontos suficientes para trocar.");
        Associado = associado;

        associado.SubtrairPontos(produto.Pontos);
    }
}
