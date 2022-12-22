using domain.CadastroDeAtividades.Entidades;
using domain.CadastroDeAtividades.Repositorio;
using MongoDB.Driver;

namespace infra.CadastroDeAtividades.Repositorio;
public class Atividades : IAtividades
{
    private readonly IMongoCollection<Atividade> _atividades;
    public Atividades(ContribuicoesContexto contribuicoesContexto)
    {
        _atividades = contribuicoesContexto.Atividades;
    }

    public async Task Alterar(Atividade atividade)
       => await _atividades.ReplaceOneAsync(x => x.Id == atividade.Id, atividade);

    public async Task Excluir(Atividade atividade)
       => await _atividades.DeleteOneAsync(x => x.Id == atividade.Id);

    public async Task Incluir(Atividade atividade)
       => await _atividades.InsertOneAsync(atividade);

    public async Task<Atividade> ObterPorId(string Id)
        => (await _atividades.FindAsync(x => x.Id == Id)).FirstOrDefault();
}
