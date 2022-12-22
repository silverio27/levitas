using api.Extensoes;
using api.SeedWork;
using domain.CadastroDeAtividades.Entidades;
using domain.CadastroDeAtividades.Repositorio;
using FluentValidation;
using MediatR;

namespace api.CadastroDeAtiividades.Comandos;
public class RecrutadorDaAtividade
{
   public string? IdDeUsuario {get; set;}
   public  string? Nome {get; set;}
}
public class NovoContribuidor : IRequest<Resposta>
{
    public RecrutadorDaAtividade? Recrutador { get; set; }
    public string? IdDeUsuario { get; set; }
    public string? Nome { get; set; }
    public string? IdDaAtividade { get; set; }

}

public class NovoContribuidorValidacao : AbstractValidator<NovoContribuidor>
{
    private readonly IAtividades _atividades;
    public NovoContribuidorValidacao(IAtividades atividades)
    {
        _atividades = atividades;
        RuleFor(x => x.IdDeUsuario).NotEmpty().WithMessage("Um id de usuário é obrigatório.");
        RuleFor(x => x.IdDaAtividade).NotEmpty().WithMessage("Um id de atividade é obrigatório.");
        RuleFor(x => x.Nome).NotEmpty().WithMessage("O nome de usuário é obrigatório.");
        RuleFor(x => x.Recrutador).NotNull().WithMessage("O recrutador é obrigatório.");


        RuleFor(x => x.IdDaAtividade).MustAsync(async (id, cancellation) =>
        {
            var atividade = await _atividades.ObterPorId(id!);
            return atividade is not null;
        }).WithMessage("A atividade que você está tentando incluir um contribuidor, não existe.");
    }
}


public class RecrutarContribuidor : IRequestHandler<NovoContribuidor, Resposta>
{
    private readonly IAtividades _atividades;

    public RecrutarContribuidor(IAtividades atividades)
    {
        _atividades = atividades;
    }

    public async Task<Resposta> Handle(NovoContribuidor request, CancellationToken cancellationToken)
    {
        var validator = new NovoContribuidorValidacao(_atividades);
        var validate = await validator.ValidateAsync(request);
        if (!validate.IsValid)
            return Resposta.Fail("Não foi possível incluir o contribuidor", request, validate.ToNotificacoes());

        Atividade atividade = await _atividades.ObterPorId(request.IdDaAtividade!);

        Contribuidor contribuidor = new(
            idDeUsuario: request.IdDeUsuario!,
            nome: request.Nome!,
            recrutador: new(
                request.Recrutador!.IdDeUsuario!, 
                request.Recrutador.Nome!));

        atividade.Ingressar(contribuidor);

        await _atividades.Alterar(atividade);

        return Resposta.Ok("Contribuidor incluído", contribuidor);
    }
}
