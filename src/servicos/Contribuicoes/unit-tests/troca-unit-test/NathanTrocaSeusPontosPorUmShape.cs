using domain.IdentidadeEAcesso;
using mocks_para_tests;

namespace troca_unit_test;

public class NathanTrocaSeusPontosPorUmShape
{
    [Fact]
    public void Trocar_pontos()
    {
        Criador criador = new(Usuarios.Dyego);

        Associado associado = new(Usuarios.Nathan, criador);
        associado.AdicionarPontos(20);

        Produtos.ShapeNssb.AtualizarEstoque(2, criador);
        Produtos.ShapeNssb.AtualizarValorDosPontos(13, criador);
        Produtos.ShapeNssb.Desbloquear();

        associado.SolicitarResgate(Produtos.ShapeNssb);

        Assert.Equal(7, associado.Pontos);
        Assert.Equal(1, Produtos.ShapeNssb.QuantidadeEmEstoque);
    }

}
