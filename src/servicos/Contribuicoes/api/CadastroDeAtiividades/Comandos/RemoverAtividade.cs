using api.Extensoes;
using api.SeedWork;
using domain.CadastroDeAtividades.Entidades;
using domain.CadastroDeAtividades.Repositorio;
using FluentValidation;
using MediatR;

namespace api.CadastroDeAtiividades.Comandos
{
    public class AtividadeParaRemover :  IRequest<Resposta>
    {
        public string? Id { get; set; }
    }

    public class AtividadeParaRemoverValidacao : AbstractValidator<AtividadeParaRemover>
    {
        private readonly IAtividades _atividades;
        public AtividadeParaRemoverValidacao(IAtividades atividades)
        {
            _atividades = atividades;
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id da atividade é obrigatório");

            RuleFor(x => x.Id).MustAsync(async (id, cancellation) =>
            {
                var atividade = await _atividades.ObterPorId(id!);
                return atividade is not null;
            }).WithMessage("A atividade que você está tentando excluir não existe.");

        }
    }

    public class RemoverAtividade : IRequestHandler<AtividadeParaRemover, Resposta>
    {
        private readonly IAtividades _atividades;
        public RemoverAtividade(IAtividades atividades)
        {
            _atividades = atividades;
        }
        public async Task<Resposta> Handle(AtividadeParaRemover request, CancellationToken cancellationToken)
        {
            var validator = new AtividadeParaRemoverValidacao(_atividades);
            var validate = await validator.ValidateAsync(request);
            if (!validate.IsValid)
                return Resposta.Fail("Não foi possível excluir a atividade.", request, validate.ToNotificacoes());

            Atividade atividade = await _atividades.ObterPorId(request.Id!);
            await _atividades.Excluir(atividade);

            return Resposta.Ok("Atividade removida", request);
        }
    }
}