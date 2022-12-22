using api.Extensoes;
using api.SeedWork;
using domain.CadastroDeAtividades.Entidades;
using domain.CadastroDeAtividades.Repositorio;
using FluentValidation;
using MediatR;

namespace api.CadastroDeAtiividades.Comandos;
public class InformanteDaFalta
{
    public string? IdDeUsuario { get; set; }
    public string? Nome { get; set; }
}
public class Falta : IRequest<Resposta>
{
    public InformanteDaFalta? Informante { get; set; }
    public string? IdDoContribuidor { get; set; }
    public string? IdDaAtividade { get; set; }
}

public class FaltaValidacao : AbstractValidator<Falta>
{
    IAtividades _atividades;
    public FaltaValidacao(IAtividades atividades)
    {
        _atividades = atividades;
        RuleFor(x => x.Informante).NotNull().WithMessage("Um informante é obrigatório.");
        RuleFor(x => x.IdDoContribuidor).NotEmpty().WithMessage("A id do contribuidor é obrigatório.");
        RuleFor(x => x.IdDaAtividade).NotEmpty().WithMessage("A id da atividade é obrigatória.");


        RuleFor(x => x).MustAsync(async (falta, cancellation) =>
           {
               var atividade = await _atividades.ObterPorId(falta.IdDaAtividade!);
               var contribuidor = atividade.Contribuidores.FirstOrDefault(x=>x.Id == falta.IdDoContribuidor);

               return atividade is not null && contribuidor is not null;
           }).WithMessage("A atividade ou contribuidor que você está tentando alterar não existe.");

    }
}

public class InformarFalta : IRequestHandler<Falta, Resposta>
{
    IAtividades _atividades;

    public InformarFalta(IAtividades atividade)
    {
        _atividades = atividade;
    }

    public async Task<Resposta> Handle(Falta request, CancellationToken cancellationToken)
    {
        var validate = await new FaltaValidacao(_atividades).ValidateAsync(request);
        if (!validate.IsValid)
            return Resposta.Fail("Não foi possível informar a falta", validate.ToNotificacoes());

        Atividade atividade = await _atividades.ObterPorId(request.IdDaAtividade!);

        atividade.InformarFalta(
            informante: new(request.Informante!.IdDeUsuario!, request.Informante!.Nome!),
           IdDoContribuidor: request.IdDoContribuidor!);

        await _atividades.Alterar(atividade);

        return Resposta.Ok("Falta informada.");
    }
}