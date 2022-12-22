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
public class InformanteDoEncerramento
{
    public string? IdDeUsuario { get; set; }
    public string? Nome { get; set; }
}
public class AtividadeParaEncerrar : IRequest<Resposta>
{
    public InformanteDoEncerramento? InformanteDoEncerramento { get; set; }
    public string? IdDaAtividade { get; set; }
}
public class AtividadeParaEncerrarValidacao : AbstractValidator<AtividadeParaEncerrar>
{
    IAtividades _atividades;
    public AtividadeParaEncerrarValidacao(IAtividades atividades)
    {
        _atividades = atividades;
        RuleFor(x => x.IdDaAtividade).NotEmpty().WithMessage("Id da atividade é obrigatório.");
        RuleFor(x => x.IdDaAtividade).MustAsync(async (id, cancellation) =>
        {
            var atividade = await _atividades.ObterPorId(id!);
            return atividade is not null;
        });
    }
}
public class Encerrar : IRequestHandler<AtividadeParaEncerrar, Resposta>
{
    IAtividades _atividades;

    public Encerrar(IAtividades atividades)
    {
        _atividades = atividades;
    }

    public async Task<Resposta> Handle(AtividadeParaEncerrar request, CancellationToken cancellationToken)
    {
        var validate = await new AtividadeParaEncerrarValidacao(_atividades).ValidateAsync(request);
        if (!validate.IsValid)
            return Resposta.Fail("Não foi posssível encerrar a atividade", validate.ToNotificacoes());

        Atividade atividade = await _atividades.ObterPorId(request.IdDaAtividade!);

        atividade.Encerrar(
            new(idDeUsuario: request.InformanteDoEncerramento!.IdDeUsuario!,
                nome: request.InformanteDoEncerramento.Nome!));

        await _atividades.Alterar(atividade);

        return Resposta.Ok("Atividade encerrada");
    }
}
