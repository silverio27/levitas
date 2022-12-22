using domain.CadastroDeAtividades.Entidades;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace infra
{
    public class ContribuicoesContexto
    {
        public readonly IMongoCollection<Atividade> Atividades;
        public ContribuicoesContexto(IOptions<MongoSettings> mongoDBSettings)
        {
            MongoClient client = new(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            Atividades = database.GetCollection<Atividade>(nameof(Atividade));
        }
    }
}