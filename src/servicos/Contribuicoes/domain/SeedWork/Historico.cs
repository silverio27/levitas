using System.Text.Json.Serialization;

namespace domain.SeedWork;
public class Historico 
{
    public Historico(string mensagem)
    {
        Mensagem = mensagem;
    }
    public string Mensagem { get; private set; }
}
