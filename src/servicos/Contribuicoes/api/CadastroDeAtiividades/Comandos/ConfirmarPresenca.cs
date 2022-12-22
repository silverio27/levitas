using api.SeedWork;
using FluentValidation;
using MediatR;
using domain.CadastroDeAtividades.Repositorio;
using api.Extensoes;

namespace api.CadastroDeAtiividades.Comandos;
public class ContribuidorPresente : IRequest<Resposta>
{
    public string? IdDoContribuidor { get; set; }
    public string? IdDaAtividade { get; set; }
}

public class ContribuidorPresenteValidacao : AbstractValidator<ContribuidorPresente>
{
    IAtividades _atividades;
    public ContribuidorPresenteValidacao(IAtividades atividades)
    {
        _atividades = atividades;
        RuleFor(x => x.IdDaAtividade).NotEmpty().WithMessage("Id da atividade é obrigatório");
        RuleFor(x => x.IdDoContribuidor).NotEmpty().WithMessage("Id do contribuidor é obrigatório");

        RuleFor(x => x).MustAsync(async (request, cancellation) =>
        {
            var atividade = await _atividades.ObterPorId(request.IdDaAtividade!);

            return atividade is not null;
        });
        _atividades = atividades;
    }
}

public class ConfirmarPresenca : IRequestHandler<ContribuidorPresente, Resposta>
{
    IAtividades _atividades;

    public ConfirmarPresenca(IAtividades atividades)
    {
        _atividades = atividades;
    }

    public async Task<Resposta> Handle(ContribuidorPresente request, CancellationToken cancellationToken)
    {
        var validate = await new ContribuidorPresenteValidacao(_atividades).ValidateAsync(request);
        if (!validate.IsValid)
            return Resposta.Fail("Não foi possível confirmar a presença", validate.ToNotificacoes());

        var atividade = await _atividades.ObterPorId(request.IdDaAtividade!);
        atividade.ConfirmarPresenca(request.IdDoContribuidor!);
        await _atividades.Alterar(atividade);
        
        return Resposta.Ok("Presença confirmada");
    }
}
