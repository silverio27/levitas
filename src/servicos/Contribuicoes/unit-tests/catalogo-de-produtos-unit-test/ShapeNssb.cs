
using domain.CatalogoDeProdutos.Entidades;
using domain.CatalogoDeProdutos.Enumeraveis;
using domain.IdentidadeEAcesso;
using mocks_para_tests;
using Xunit.Priority;

namespace catalogo_de_produtos_unit_test;

[TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
public class ShapeNssb
{
    static Criador dyego = new(Usuarios.Dyego);
    static Produto shapeNssb = new("Shape NSSB Logo Clássica", dyego, "New Stone SkateBoard");

    [Fact, Priority(0)]
    public void Dyego_incluiu_um_novo_produto_no_catalogo()
    {
        Assert.Equal(StatusDoProduto.Bloqueado, shapeNssb.Status);
    }

    [Fact, Priority(1)]
    public void Dyego_atualizou_o_estoque_para_a_quantidade_um()
    {
        shapeNssb.AtualizarEstoque(quantidade: 1, criador: dyego);
        
        Assert.Equal(1, shapeNssb.QuantidadeEmEstoque);
    }

    [Fact, Priority(2)]
    public void Dyego_bloqueou_o_produto()
    {
        shapeNssb.Bloquear(dyego);

        Assert.Equal(StatusDoProduto.Bloqueado, shapeNssb.Status);
    }

    [Fact, Priority(3)]
    public void Dyego_atualizou_o_valor_dos_pontos()
    {
        shapeNssb.AtualizarValorDosPontos(13, dyego);

        Assert.Equal(13, shapeNssb.Pontos);
    }

    [Fact, Priority(4)]
    public void Dyego_adicionou_2_fotos_ao_produto()
    {
        shapeNssb.AdicionarFoto("fotos/shape.png", dyego);
        shapeNssb.AdicionarFoto("fotos/roda.png", dyego);

        Assert.Equal(2, shapeNssb.UrlFotos.Count);
    }

    [Fact, Priority(5)]
    public void Dyego_remove_a_foto_da_roda()
    {
        shapeNssb.RemoverFoto("fotos/roda.png", dyego);

        Assert.Single(shapeNssb.UrlFotos);
    }
}
