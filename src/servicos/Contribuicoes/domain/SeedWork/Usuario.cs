namespace domain.SeedWork;
public abstract class Usuario
{
    protected Usuario(string idDeUsuario, string nome)
    {
        IdDeUsuario = idDeUsuario;
        Nome = nome;
    }

    public string IdDeUsuario { get; private set; }
    public string Nome { get; private set; }
}
