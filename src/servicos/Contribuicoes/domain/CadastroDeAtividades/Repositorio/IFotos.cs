using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domain.CadastroDeAtividades.Repositorio;
public interface IFotos
{
    Task<string> Upload(string base64);
    Task Remover(string id);
}
