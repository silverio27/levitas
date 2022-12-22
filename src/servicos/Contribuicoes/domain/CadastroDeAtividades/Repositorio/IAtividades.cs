using domain.CadastroDeAtividades.Entidades;
using domain.IdentidadeEAcesso;

namespace domain.CadastroDeAtividades.Repositorio;
public interface IAtividades
{
    Task Incluir(Atividade atividade);
    Task Excluir(Atividade atividade);
    Task Alterar(Atividade atividade);
    Task<Atividade> ObterPorId(string Id);
}
