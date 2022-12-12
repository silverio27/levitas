using domain.SeedWork;

namespace mocks_para_tests;
public class UsuarioMock : Usuario
{
    public UsuarioMock(string idDeUsuario, string nome) : base(idDeUsuario, nome)
    {
    }
}

public class Usuarios
{
    public static UsuarioMock Nathan = new(idDeUsuario: "e2dbe8e7-7f45-4d8b-bbb3-c4a8c8c865b8", nameof(Nathan));
    public static UsuarioMock Felix = new(idDeUsuario: "c5b4c798-fa09-4a52-882e-5e5f3bc9f12b", nameof(Felix));
    public static UsuarioMock Dyego = new(idDeUsuario: "36d2f1ce-6d9a-4b66-a2ea-f05b2757c0bf", nameof(Dyego));
    public static UsuarioMock Jhuan = new(idDeUsuario: "a700991d-92af-465f-9fe5-adbe561e9748", nameof(Jhuan));
    public static UsuarioMock Andre = new(idDeUsuario: "7c11904a-a039-4349-bf79-116a5488485c", nameof(Andre));
}
