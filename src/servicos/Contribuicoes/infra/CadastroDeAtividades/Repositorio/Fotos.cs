using domain.CadastroDeAtividades.Repositorio;

namespace infra.CadastroDeAtividades.Repositorio;
public class Fotos : IFotos
{
    StorageContext _context;

    public Fotos(StorageContext context)
    {
        _context = context;
    }

    public async Task Remover(string id)
    {
        await _context.Fotos.GetBlobClient(id).DeleteAsync();
    }

    public async Task<string> Upload(string base64)
    {
        var nome = Guid.NewGuid().ToString() + ".jpeg";
        var conteudoBytes = Convert.FromBase64String(base64);
        var conteudoMemoryStream = new MemoryStream(conteudoBytes);
        var uploaded = await _context.Fotos.UploadBlobAsync(nome, conteudoMemoryStream);
        return nome;
    }
}
