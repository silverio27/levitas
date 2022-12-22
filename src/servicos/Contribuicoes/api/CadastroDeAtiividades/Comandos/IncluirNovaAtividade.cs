using api.Extensoes;
using api.SeedWork;
using domain.CadastroDeAtividades.Entidades;
using domain.CadastroDeAtividades.Enumeraveis;
using domain.CadastroDeAtividades.Repositorio;
using domain.IdentidadeEAcesso;
using FluentValidation;
using MediatR;

namespace api.CadastroDeAtiividades.Comandos;
public record Organizador(string IdDeUsuario, string Nome);
public class NovaAtividade : IRequest<Resposta>
{
    public string? Descricao { get; set; }
    public string? Nome { get; set; }
    public Tamanho Tamanho { get; set; }
    public DateTime DataDaExecucao { get; set; }
    public Organizador? Organizador { get; set; }
}

public class NovaAtividadeValidacao : AbstractValidator<NovaAtividade>
{
    public NovaAtividadeValidacao()
    {
        RuleFor(x => x.Descricao).NotEmpty().WithMessage("A descrição é obrigatória.");
        RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome é obrigatório.");
        RuleFor(x => x.Organizador).NotNull().WithMessage("Organizador é obrigatório.");
    }
}

public class IncluirNovaAtividade : IRequestHandler<NovaAtividade, Resposta>
{
    private readonly IAtividades _atividades;
    public IncluirNovaAtividade(IAtividades atividaes)
    {
        _atividades = atividaes;
    }
    public async Task<Resposta> Handle(NovaAtividade request, CancellationToken cancellationToken)
    {

        var validate = new NovaAtividadeValidacao().Validate(request);
        if (!validate.IsValid)
            return Resposta.Fail("Atividade inválida", request, validate.ToNotificacoes());

        Criador criador = new(request.Organizador!.IdDeUsuario, request.Organizador.Nome);
        var atividade = new Atividade(
            nome: request.Nome!,
            descricao: request.Descricao!,
            tamanho: request.Tamanho,
            dataDaExecucao: request.DataDaExecucao,
            criador: criador);

        await _atividades.Incluir(atividade);

        return Resposta.Ok("Nova atividade incluída.", atividade);
    }


}
