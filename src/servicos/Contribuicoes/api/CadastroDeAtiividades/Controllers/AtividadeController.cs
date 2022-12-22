using api.CadastroDeAtiividades.Comandos;
using api.SeedWork;
using domain.CadastroDeAtividades.Entidades;
using domain.CadastroDeAtividades.Repositorio;
using infra;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace api.CadastroDeAtiividades.Controllers;

[ApiController]
[Route("[controller]")]
public class AtividadeController : ControllerBase
{
    private readonly ILogger<AtividadeController> _logger;
    private readonly IMediator _mediator;
    private readonly IAtividades _atividades;
    private readonly ContribuicoesContexto _contexto;

    public AtividadeController(ILogger<AtividadeController> logger, IMediator mediator, IAtividades atividades, ContribuicoesContexto contexto)
    {
        _logger = logger;
        _mediator = mediator;
        _atividades = atividades;
        _contexto = contexto;
    }

    [HttpGet("{id}")]
    public async Task<Atividade> Obter(string id) => await _atividades.ObterPorId(id);

    [HttpGet]
    public async Task<List<Atividade>> Obter() => await _contexto.Atividades.Find(new BsonDocument()).ToListAsync();

    [HttpPost]
    public async Task<ActionResult> Criar(NovaAtividade novaAtividade)
    {
        var resposta = await _mediator.Send(novaAtividade);
        if (resposta.Sucesso)
            return CreatedAtAction(nameof(Obter), new { id = resposta.Dados!.Id }, resposta.Dados);

        return BadRequest(resposta);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Excluir(string id)
    {
        AtividadeParaRemover atividadeParaRemover = new() { Id = id };
        var resposta = await _mediator.Send(atividadeParaRemover);
        if (resposta.Sucesso)
            return NoContent();

        return BadRequest(resposta);
    }

    [HttpPut("incluir-contribuidor/{atividadeId}")]
    public async Task<ActionResult> IncluirContribuidor(string atividadeId, NovoContribuidor novoContribuidor)
    {
        if (atividadeId != novoContribuidor.IdDaAtividade)
            return BadRequest(Resposta.Fail("Id da atividade divergente no parametro e no corpo da requisição."));

        var resposta = await _mediator.Send(novoContribuidor);
        if (resposta.Sucesso)
            return NoContent();

        return BadRequest(resposta);
    }

    [HttpPut("informar-falta/{atividadeId}")]
    public async Task<ActionResult> InformarFalta(string atividadeId, Falta falta)
    {
        if (atividadeId != falta.IdDaAtividade)
            return BadRequest(Resposta.Fail("Id da atividade divergente no parametro e no corpo da requisição."));

        var resposta = await _mediator.Send(falta);
        if (resposta.Sucesso)
            return NoContent();

        return BadRequest(resposta);
    }

    [HttpPut("sair/{atividadeId}")]
    public async Task<ActionResult> Sair(string atividadeId, ContribuidorQueVaiSair contribuidorQueVaiSair)
    {
        if (atividadeId != contribuidorQueVaiSair.IdDaAtividade)
            return BadRequest(Resposta.Fail("Id da atividade divergente no parametro e no corpo da requisição."));

        var resposta = await _mediator.Send(contribuidorQueVaiSair);
        if (resposta.Sucesso)
            return NoContent();

        return BadRequest(resposta);
    }

    [HttpPut("encerrar/{atividadeId}")]
    public async Task<ActionResult> Encerrar(string atividadeId, AtividadeParaEncerrar atividadeParaEncerrar)
    {
        if (atividadeId != atividadeParaEncerrar.IdDaAtividade)
            return BadRequest(Resposta.Fail("Id da atividade divergente no parametro e no corpo da requisição."));

        var resposta = await _mediator.Send(atividadeParaEncerrar);
        if (resposta.Sucesso)
            return NoContent();

        return BadRequest(resposta);
    }

    [HttpPut("confirmar-presenca/{atividadeId}")]
    public async Task<ActionResult> ConfirmarPresenca(string atividadeId, ContribuidorPresente contribuidorPresente)
    {
        if (atividadeId != contribuidorPresente.IdDaAtividade)
            return BadRequest(Resposta.Fail("Id da atividade divergente no parametro e no corpo da requisição."));

        var resposta = await _mediator.Send(contribuidorPresente);
        if (resposta.Sucesso)
            return NoContent();

        return BadRequest(resposta);
    }
}
