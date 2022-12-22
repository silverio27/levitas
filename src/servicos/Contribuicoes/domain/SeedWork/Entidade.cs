

using domain.IdentidadeEAcesso;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace domain.SeedWork;
public abstract class Entidade
{
    
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; private set; }

    protected Entidade(DateTime criadoEm, Criador criador)
    {        
        Id = ObjectId.GenerateNewId().ToString();
        CriadoEm = criadoEm;
        Criador = criador;
    }

    public DateTime CriadoEm { get; protected set; }
    public Criador Criador { get; protected set; }
    public DateTime? UltimaAlteracao { get; private set; }

    public void AtualizarDataDeAlteracao() => UltimaAlteracao = DateTime.UtcNow;

}
