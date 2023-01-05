using api.SeedWork;
using FluentValidation;
using MediatR;
using domain.CadastroDeAtividades.Repositorio;
using api.Extensoes;
using domain.CadastroDeAtividades.Entidades;
using domain.IdentidadeEAcesso;
using api.CadastroDeAtiividades.Eventos;

namespace api.CadastroDeAtiividades.Comandos;
public class FotoASerRemovida : IRequest<Resposta>
{
    public Organizador? Organizador { get; set; }
    public string? IdDaFoto { get; set; }
    public string? IdDaAtividade { get; set; }
}
public class FotoASerRemovidaValidacao : AbstractValidator<FotoASerRemovida>
{
    IAtividades _atividades;
    public FotoASerRemovidaValidacao(IAtividades atividades)
    {
        _atividades = atividades;
        RuleFor(x => x.IdDaAtividade).NotEmpty().WithMessage("Id da atividade é obrigatório.");
        RuleFor(x => x.IdDaFoto).NotEmpty().WithMessage("Id da foto é obrigatório.");

        RuleFor(x => x).MustAsync(async (request, cancell) =>
        {
            var atividade = await _atividades.ObterPorId(request.IdDaAtividade!);
            var foto = atividade.Fotos.FirstOrDefault(x => x.Id == request.IdDaFoto);
            return atividade is not null && foto is not null;
        }).WithMessage("Atividade ou foto não encontrada.");
        _atividades = atividades;
    }
}
public class RemoverFoto : IRequestHandler<FotoASerRemovida, Resposta>
{
    IAtividades _atividades;
    IMediator _mediator;

    public RemoverFoto(IAtividades atividades, IMediator mediator)
    {
        _atividades = atividades;
        _mediator = mediator;
    }

    public async Task<Resposta> Handle(FotoASerRemovida request, CancellationToken cancellationToken)
    {
        var validate = await new FotoASerRemovidaValidacao(_atividades).ValidateAsync(request);
        if (!validate.IsValid)
            return Resposta.Fail("Não foi possível remover a foto.", validate.ToNotificacoes());

        Atividade atividade = await _atividades.ObterPorId(request.IdDaAtividade!);
        Criador criador = new(request.Organizador!.IdDeUsuario, request.Organizador.Nome);

        var nomeDaFoto = atividade.Fotos.FirstOrDefault(x=>x.Id == request.IdDaFoto)!.Nome;
        atividade.RemoverFoto(criador, request.IdDaFoto!);

        await _atividades.Alterar(atividade);

        var fotoDoStorage = new FotoDoStorage(){Nome = nomeDaFoto};

        await _mediator.Publish(fotoDoStorage);
        
        return Resposta.Ok("Foto removida");
    }
}
