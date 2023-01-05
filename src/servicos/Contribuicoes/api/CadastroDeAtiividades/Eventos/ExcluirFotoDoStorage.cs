using domain.CadastroDeAtividades.Repositorio;
using MediatR;

namespace api.CadastroDeAtiividades.Eventos;
public class FotoDoStorage : INotification
{
    public string? Nome { get; set; }
}
public class FotosDoStorage : INotification
{
    public List<string>? Nomes { get; set; }
}
public class ExcluirFotoDoStorage : 
    INotificationHandler<FotoDoStorage>,
    INotificationHandler<FotosDoStorage>
{
    IFotos _fotos;

    public ExcluirFotoDoStorage(IFotos fotos)
    {
        _fotos = fotos;
    }

    public async Task Handle(FotoDoStorage notification, CancellationToken cancellationToken)
    {
        await _fotos.Remover(notification.Nome!);
    }

    public async Task Handle(FotosDoStorage notification, CancellationToken cancellationToken)
    {
        var tasks = notification.Nomes!.Select(x => _fotos.Remover(x)).ToList();
        await Task.WhenAll(tasks);
    }
}
