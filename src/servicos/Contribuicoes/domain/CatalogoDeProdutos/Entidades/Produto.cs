using System.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.CadastroDeAtividades.ObjetosDeValor;
using domain.CatalogoDeProdutos.Enumeraveis;
using domain.CatalogoDeProdutos.Excessoes;
using domain.SeedWork;
using domain.CatalogoDeProdutos.ObjetosDeValor;

namespace domain.CatalogoDeProdutos.Entidades;
public class Produto : RaizDaAgregacao
{
    public string Nome { get; private set; }
    public string Fornecedor { get; private set; }
    public int QuantidadeEmEstoque { get; private set; }
    public int Pontos { get; private set; }
    public List<string> UrlFotos { get; private set; }
    public StatusDoProduto Status { get; private set; }

    public Produto(string nome, Criador criador, string fornecedor) : base(criador)
    {
        Nome = nome;
        Fornecedor = fornecedor;
        Status = StatusDoProduto.Bloqueado;
        UrlFotos = new();
        AdicionarAlteracaoAoHistorico($"{criador.Nome} adicionou o novo produto.");
    }

    public void AtualizarEstoque(int quantidade, Criador criador)
    {
        if (quantidade == 0)
            Status = StatusDoProduto.Acabou;
        QuantidadeEmEstoque = quantidade;

        AdicionarAlteracaoAoHistorico($"{criador.Nome}alterou a quantidade para {quantidade}.");
    }

    public void Bloquear(Criador criador)
    {
        Status = StatusDoProduto.Bloqueado;
        AdicionarAlteracaoAoHistorico($"{criador.Nome} bloqueou o produto.");
    }

    public void Desbloquear()
    {
        if (QuantidadeEmEstoque == 0)
            throw new ProdutoException("Produto sem estoque não pode ser desbloqueado.");
        Status = StatusDoProduto.Disponivel;
    }
    public void AtualizarValorDosPontos(int pontos, Criador criador)
    {
        if (pontos <= 0)
            throw new ProdutoException("Um produto não pode vale menos de um ponto.");
        Pontos = pontos;

        AdicionarAlteracaoAoHistorico($"{criador.Nome} alterou o valor do ponto para {pontos}");
    }

    public void AdicionarFoto(string urlFoto, Criador criador)
    {
        UrlFotos.Add(urlFoto);

        AdicionarAlteracaoAoHistorico($"{criador.Nome} adicionou uma foto {urlFoto}");
    }

    public void RemoverFoto(string url, Criador criador)
    {
        var foto = UrlFotos.Find(x => x == url);
        if (foto is null)
            throw new ProdutoException("A foto informada não existe.");

        UrlFotos.Remove(foto);

        AdicionarAlteracaoAoHistorico($"{criador.Nome} removeu uma foto.");
    }

    public void SubtrairEstoque(int quantidade = 1)
    {
        if (QuantidadeEmEstoque <= 0)
            throw new ProdutoException("Não há estoque suficiente.");
        QuantidadeEmEstoque -= quantidade;
    }
}
