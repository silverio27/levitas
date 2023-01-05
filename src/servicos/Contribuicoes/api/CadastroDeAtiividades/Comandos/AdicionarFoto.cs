using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Extensoes;
using api.SeedWork;
using domain.CadastroDeAtividades.Entidades;
using domain.CadastroDeAtividades.Repositorio;
using domain.IdentidadeEAcesso;
using FluentValidation;
using MediatR;

namespace api.CadastroDeAtiividades.Comandos
{
    public class FotoASerAdicionada : IRequest<Resposta>
    {
        public string? IdDaAtividade { get; set; }
        public string? Base64 { get; set; }
        public string? Descricao { get; set; }
        public string? Sessao { get; set; }
        public Organizador? Organizador { get; set; }
    }

    public class FotoASerAdicionadaValidacao : AbstractValidator<FotoASerAdicionada>
    {
        IAtividades _atividades;
        public FotoASerAdicionadaValidacao(IAtividades atividades)
        {
            _atividades = atividades;
            RuleFor(x => x.Organizador).NotNull().WithMessage("Organizador não pode ser nulo.");
            RuleFor(x => x.IdDaAtividade).NotEmpty().WithMessage("Id da atividade é obrigatório");
            RuleFor(x => x.Descricao).NotEmpty().WithMessage("Descrição da foto é obrigatório");
            RuleFor(x => x.Base64).NotEmpty().WithMessage("Base64 da foto é obrigatório");
            RuleFor(x => x.IdDaAtividade).MustAsync(async (id, cancellation) =>
            {
                var atividade = await _atividades.ObterPorId(id!);
                return atividade is not null;
            });
        }

    }
    public class AdicionarFoto : IRequestHandler<FotoASerAdicionada, Resposta>
    {
        IAtividades _atividades;
        IFotos _fotos;
        public AdicionarFoto(IAtividades atividades, IFotos fotos)
        {
            _atividades = atividades;
            _fotos = fotos;
        }

        public async Task<Resposta> Handle(FotoASerAdicionada request, CancellationToken cancellationToken)
        {
            var validate = await new FotoASerAdicionadaValidacao(_atividades).ValidateAsync(request);
            if (!validate.IsValid)
                return Resposta.Fail("Não foi possível adicionar a foto", validate.ToNotificacoes());

            var nomeDaFoto = await _fotos.Upload(request.Base64!);

            var atividade = await _atividades.ObterPorId(request.IdDaAtividade!);
            Criador criador = new(request.Organizador!.IdDeUsuario, request.Organizador.Nome);
            var foto = new Foto(request.Descricao!, request.Sessao!, nomeDaFoto, criador);
            atividade.AdicionarFoto(criador, foto);
            await _atividades.Alterar(atividade);

            return Resposta.Ok("Foto adicionada");
        }
    }
}