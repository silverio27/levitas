namespace api.SeedWork;
public class Resposta
{
    public Resposta(bool sucesso, string mensagem, object? dados = null, List<string>? notificacoes = null)
    {
        Sucesso = sucesso;
        Mensagem = mensagem;
        Dados = dados;
        Notificacoes = notificacoes;
    }

    public bool Sucesso { get; private set; }
    public string Mensagem { get; private set; }
    public dynamic? Dados { get; private set; }
    public List<string>? Notificacoes { get; private set; }

    public static Resposta Ok(string mensagem, object? dados = null) 
        => new Resposta(true, mensagem, dados);

    public static Resposta Fail(string mensagem, object? dados = null, List<string>? notificacoes = null) 
        => new Resposta(false, mensagem, dados, notificacoes);
}
