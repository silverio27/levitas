using domain.GestaoDePontos.Entidades;
using mocks_para_tests;
using Xunit.Abstractions;
using Xunit.Priority;

namespace gestao_de_pontos_unit_test;

[TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
public class Capina
{
    static UsuarioMock dyego = Usuarios.Dyego;
    static Associado nathan = new(usuario: Usuarios.Nathan, criador: new(dyego));
    static Associado andre = new(usuario: Usuarios.Andre, criador: new(dyego));
    static ValorDosPontos valorDosPontos = new ValorDosPontos(new(Usuarios.Dyego), 5.51);
    ITestOutputHelper _output;
    public Capina(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact, Priority(0)]
    public void Nathan_e_incluido_como_associado()
    {
        Assert.Equal(0, nathan.Pontos);
    }

    [Fact, Priority(1)]
    public void Nathan_ganhou_4_pontos_pela_presenca_na_atividade_capina()
    {
        nathan.GanhouPontos(4, nameof(Nathan_ganhou_4_pontos_pela_presenca_na_atividade_capina));
        Assert.Equal(4, nathan.Pontos);
    }

    [Fact, Priority(2)]
    public void Andre_perdeu_4_pontos_pela_falta_na_atividade_capina()
    {
        andre.PerderPontos(4, nameof(Andre_perdeu_4_pontos_pela_falta_na_atividade_capina));
        Assert.Equal(-4, andre.Pontos);
    }

    [Fact, Priority(3)]
    public void Dyego_atualizou_o_valor_dos_pontos_para_o_valor_da_hora_do_salario_minimo_atual()
    {
        Assert.True(valorDosPontos.Vigente);
    }

    [Fact, Priority(4)]
    public void Nathan_visualiza_o_valor_dos_seus_pontos()
    {
        nathan.AtualizarConversaoDosPontos(valorDosPontos);

        Assert.Equal(22.04, nathan.MeusPontos.ValorDosPontosConvertidos);
    }

}
