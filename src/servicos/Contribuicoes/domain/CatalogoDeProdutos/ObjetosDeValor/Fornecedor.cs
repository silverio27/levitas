using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.SeedWork;

namespace domain.CatalogoDeProdutos.ObjetosDeValor
{
    public class Fornecedor : Usuario
    {
        public Fornecedor(string idDeUsuario, string nome) : base(idDeUsuario, nome){}
    }
}