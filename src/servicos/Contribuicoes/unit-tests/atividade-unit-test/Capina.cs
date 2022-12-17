using System.Text.Json;
using domain.CadastroDeAtividades.Entidades;
using domain.CadastroDeAtividades.Enumeraveis;
using domain.IdentidadeEAcesso;
using mocks_para_tests;
using Xunit.Abstractions;
using Xunit.Priority;

namespace atividade_unit_test;

[TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
public class Capina
{
    static UsuarioMock dyego = Usuarios.Dyego;
    static Atividade capina = new Atividade(
            nome: "Capina",
            descricao: "fazer uma capina em volta da quadra, encontramos escorpiões no local devido a entulhos jogado no local.",
            tamanho: Tamanho.G,
            dataDaExecucao: new DateTime(2022, 11, 13, 8, 0, 0),
            criador: new(dyego)
        );
    ITestOutputHelper _logger;
    public Capina(ITestOutputHelper logger)
    {
        _logger = logger;
    }

    [Fact, Priority(1)]
    public void Atividade_e_criada_com_o_status_de_a_fazer()
        => Assert.Equal(StatusDaAtividade.AFazer, capina.Status);

    [Fact, Priority(2)]
    public void Atividade_Capina_vale_4_pontos()
        => Assert.Equal(4, capina.Pontos);

    [Fact, Priority(3)]
    public void Duracao_da_atividade_De_800_ao_1200()
        => Assert.Equal("08:00 ao 12:00", capina.Duracao);

    [Fact, Priority(4)]
    public void Dyego_inclui_3_contribuidores_todos_consentiram_e_confirmaram_presenca()
    {
        Recrutador recrutador = new(dyego);
        List<Contribuidor> contribuidores = Obter_contribuidores_da_atividade_capina();

        contribuidores.ForEach((contribuidor) => capina.Ingressar(contribuidor));
        List<Contribuidor> contribuidoresPresentes = capina.Contribuidores
             .Where(x =>
                    x.IdDeUsuario == Usuarios.Felix.IdDeUsuario ||
                    x.IdDeUsuario == Usuarios.Dyego.IdDeUsuario ||
                    x.IdDeUsuario == Usuarios.Nathan.IdDeUsuario)
             .ToList();
        contribuidoresPresentes.ForEach(x => capina.ConfirmarPresenca(x));

        Assert.Equal(3, capina.Contribuidores.Count);
        Assert.True(contribuidores.All(x => x.ConsentiuComOsTermos));
        Assert.Equal(3, capina.Contribuidores.Count(x => x.Status == StatusDoContribuidor.PresencaConfirmada));
    }

    private List<Contribuidor> Obter_contribuidores_da_atividade_capina()
    {
        Recrutador recrutador = new(dyego);
        return new()
            {
                new(atividade: capina,
                    usuario: Usuarios.Nathan,
                    recrutador: recrutador),
                new(atividade: capina,
                    usuario: Usuarios.Felix,
                    recrutador: recrutador),
                new(atividade: capina,
                    usuario: Usuarios.Dyego,
                    recrutador: recrutador)
            };
    }

    [Fact, Priority(5)]
    public void Jhuan_saiu_da_atividade()
    {
        Recrutador recrutador = new(dyego);
        Contribuidor jhuan = new(atividade: capina,
                    usuario: Usuarios.Jhuan,
                    recrutador: recrutador);

        capina.Ingressar(jhuan);
        capina.Sair(jhuan);

    }



    [Fact, Priority(7)]
    public void Andre_faltou_na_atividade()
    {
        Recrutador recrutador = new(dyego);
        Contribuidor andre = new(atividade: capina,
                    usuario: Usuarios.Andre,
                    recrutador: recrutador);

        capina.Ingressar(andre);

        capina.InformarFalta(
            informante: new(Usuarios.Dyego),
            contribuidor: andre);

        Assert.Equal(StatusDoContribuidor.Faltou, andre.Status);
    }

    [Fact, Priority(8)]
    public void Dyego_confirma_presenca_de_3_contribuidores()
    {
        List<Contribuidor> contribuidoresPresentes = capina.Contribuidores
             .Where(x =>
                    x.IdDeUsuario == Usuarios.Felix.IdDeUsuario ||
                    x.IdDeUsuario == Usuarios.Dyego.IdDeUsuario ||
                    x.IdDeUsuario == Usuarios.Nathan.IdDeUsuario)
             .ToList();

        contribuidoresPresentes.ForEach(x => capina.ConfirmarPresenca(x));

        Assert.Equal(3, capina.Contribuidores.Count(x => x.Status == StatusDoContribuidor.PresencaConfirmada));
    }

    [Fact, Priority(9)]
    public void Dyego_faz_o_upload_de_2_fotos()
    {
        Criador dyego = new(Usuarios.Dyego);
        var foto1 = new Foto(capina, "colocando a cantoneira no caixote", "", "../foto1.jpeg", dyego);
        var foto2 = new Foto(capina, "campeonato game of skate", "", "../foto2.jpeg", dyego);

        capina.AdicionarFoto(criador: dyego, foto: foto1);
        capina.AdicionarFoto(criador: dyego, foto: foto2);

        Assert.Equal(2, capina.Fotos.Count());
    }

    [Fact, Priority(10)]
    public void Dyego_encerra_a_atividade()
    {
        capina.Encerrar(new(Usuarios.Dyego));

        Assert.Equal(StatusDaAtividade.Concluido, capina.Status);

        _logger.WriteLine("Atividade");
        _logger.WriteLine("-----------");
        _logger.WriteLine("Nome: {0}", capina.Nome);
        _logger.WriteLine("Descrição: {0}", capina.Descricao);
        _logger.WriteLine("Contribuidores: {0}",
            string.Join(',', capina.Contribuidores.Select(x => x.Nome)));
        _logger.WriteLine("Status: {0}", capina.Status);
        _logger.WriteLine("Fotos: {0}", string.Join(',', capina.Fotos.Select(x => x.Url)));
        _logger.WriteLine("Tamanho: {0}", capina.Tamanho);
        _logger.WriteLine("Duração: {0}", capina.Duracao);
        _logger.WriteLine("Data da execucao: {0}", capina.DataDaExecucao);
        _logger.WriteLine("Pontos: {0}", capina.Pontos);
        _logger.WriteLine("Criado em: {0}", capina.CriadoEm);
        _logger.WriteLine("Criado por: {0}", capina.Criador.Nome);
        _logger.WriteLine("Ultima alteração: {0}", capina.UltimaAlteracao);
        _logger.WriteLine("");
        _logger.WriteLine("Contribuidores");
        _logger.WriteLine("---------");
        capina.Contribuidores.ForEach((x) =>
        {
            _logger.WriteLine("Contribuidor: {0}, Status: {1}, Consentimento: {2}",
                x.Nome, x.Status, x.ConsentiuComOsTermos);
        });

    }

}
