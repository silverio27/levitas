namespace domain.SeedWork;
public interface IRaizDaAgregacao<T> where T: Entidade
{
    List<Historico<T>> Historico { get; set; }
}
