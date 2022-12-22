using System.Linq;
using domain.CadastroDeAtividades.Enumeraveis;
using domain.IdentidadeEAcesso;
using domain.SeedWork;

namespace domain.CadastroDeAtividades.Entidades;
public class Atividade : RaizDaAgregacao
{
    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public StatusDaAtividade Status { get; private set; }
    public List<Contribuidor> Contribuidores { get; private set; }
    public List<Foto> Fotos { get; private set; }
    public Tamanho Tamanho { get; private set; }
    public string Duracao { get; private set; }
    public DateTime DataDaExecucao { get; private set; }
    public int Pontos { get { return (int)this.Tamanho; } private set { } }

    public Atividade(string nome, string descricao, Tamanho tamanho, DateTime dataDaExecucao, Criador criador)
    : base(criador: criador)
    {
        Nome = nome;
        Descricao = descricao;
        Status = StatusDaAtividade.AFazer;
        Contribuidores = new();
        Fotos = new();
        Tamanho = tamanho;
        DataDaExecucao = dataDaExecucao;
        Duracao = ObterDuracao();
        Pontos = Pontos;
        AdicionarAlteracaoAoHistorico($"Atividade '{Nome}' criada");
    }

    private string ObterDuracao() => $"{DataDaExecucao.ToString("HH:mm")} ao {DataDaExecucao.AddHours(Pontos).ToString("HH:mm")}";    

    public void Ingressar(Contribuidor contribuidor)
    {
        Contribuidores.Add(contribuidor);

        AdicionarAlteracaoAoHistorico($"{contribuidor.Nome} ingressou na atividade.");
    }

    public void ConfirmarPresenca(string idDoContribuidor)
    {
        var contribuidor = Contribuidores.First(x => x.Id == idDoContribuidor);
        contribuidor.AlterarStatusDoContribuidor(StatusDoContribuidor.PresencaConfirmada);

        AdicionarAlteracaoAoHistorico($"{contribuidor.Nome} confirmou presença na atividade.");
    }
    public void InformarFalta(Informante informante, string IdDoContribuidor)
    {
        var contribuidor = Contribuidores.FirstOrDefault(x => x.Id == IdDoContribuidor);
        contribuidor!.AlterarStatusDoContribuidor(StatusDoContribuidor.Faltou);

        AdicionarAlteracaoAoHistorico($"{informante.Nome} notificou a falta do contribuidor '{contribuidor.Nome}' na atividade.");
    }
    public void Sair(string IdDoContribuidor)
    {
        var contribuidor = Contribuidores.FirstOrDefault(x => x.Id == IdDoContribuidor);
        contribuidor!.AlterarStatusDoContribuidor(StatusDoContribuidor.Saiu);

        AdicionarAlteracaoAoHistorico($"{contribuidor.Nome} saiu da atividade.");
    }
    public void Encerrar(Criador criador)
    {
        Status = StatusDaAtividade.Concluido;
        AdicionarAlteracaoAoHistorico($"{criador.Nome} encerrou a atividade.");
    }

    public void AdicionarFoto(Criador criador, Foto foto)
    {
        Fotos.Add(foto);
        AdicionarAlteracaoAoHistorico($"{criador.Nome} adicionou uma foto.");
    }

    public void RemoverFoto(Criador criador, Foto foto)
    {
        Fotos.Remove(foto);
        AdicionarAlteracaoAoHistorico($"{criador.Nome} removeu uma foto.");
    }
}