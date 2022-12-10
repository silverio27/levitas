using System.Text.Json.Serialization;

namespace domain.SeedWork;
public class Historico<T> where T : Entidade
{
    public Historico(T atividade, string mensagem)
    {
        Atividade = atividade;
        Mensagem = mensagem;
    }
    [JsonIgnore]
    public T Atividade { get; private set; }
    public string Mensagem { get; private set; }
}
