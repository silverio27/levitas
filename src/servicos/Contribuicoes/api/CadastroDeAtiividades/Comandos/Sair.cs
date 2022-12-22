using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Extensoes;
using api.SeedWork;
using domain.CadastroDeAtividades.Entidades;
using domain.CadastroDeAtividades.Repositorio;
using FluentValidation;
using MediatR;

namespace api.CadastroDeAtiividades.Comandos;
public class ContribuidorQueVaiSair : IRequest<Resposta>
{
    public string? IdDaAtividade { get; set; }
    public string? IdDoContribuidor { get; set; }
}

public class ContribuidorQueVaiSairValidacao : AbstractValidator<ContribuidorQueVaiSair>
{
    private readonly IAtividades _atividades;
    public ContribuidorQueVaiSairValidacao(IAtividades atividades)
    {
        _atividades = atividades;
        RuleFor(x => x.IdDaAtividade).NotEmpty().WithMessage("Id da atividade é obrigatório.");
        RuleFor(x => x.IdDoContribuidor).NotEmpty().WithMessage("Id do contribuidor é obrigatório.");

        RuleFor(x => x).MustAsync(async (request, cancellation) =>
            {
                var atividade = await _atividades.ObterPorId(request.IdDaAtividade!);
                var contribuidor = atividade.Contribuidores.FirstOrDefault(x => x.Id == request.IdDoContribuidor);

                return atividade is not null && contribuidor is not null;
            });
        _atividades = atividades;
    }
}
public class Sair : IRequestHandler<ContribuidorQueVaiSair, Resposta>
{
    IAtividades _atividades;

    public Sair(IAtividades atividades)
    {
        _atividades = atividades;
    }

    public async Task<Resposta> Handle(ContribuidorQueVaiSair request, CancellationToken cancellationToken)
    {
        var validate = await new ContribuidorQueVaiSairValidacao(_atividades).ValidateAsync(request);

        if (!validate.IsValid)
            return Resposta.Fail("Não foi possível sair da tarefa", validate.ToNotificacoes());


        Atividade atividade = await _atividades.ObterPorId(request.IdDaAtividade!);

        atividade.Sair(request.IdDoContribuidor!);
        
        await _atividades.Alterar(atividade);
        var contribuidorNome = atividade.Contribuidores.FirstOrDefault(x => x.Id == request.IdDoContribuidor)!.Nome;
        return Resposta.Ok($"{contribuidorNome} saiu da atividade.");
    }
}
