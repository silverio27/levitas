using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.CadastroDeAtividades.ObjetosDeValor;
using domain.CatalogoDeProdutos.Entidades;

namespace mocks_para_tests
{
    public class ProdutoMock : Produto
    {
        public ProdutoMock(string nome, Criador criador, string fornecedor) : base(nome, criador, fornecedor)
        {
        }
    }

    public class Produtos
    {
        static Criador dyego = new(Usuarios.Dyego);
        public static ProdutoMock ShapeNssb = new("Shape NSSB Logo Clássica", dyego, "New Stone SkateBoard");
        public static ProdutoMock Roda = new("Roda", dyego, "New Stone SkateBoard");
        public static ProdutoMock Lixa = new("Lixa", dyego, "New Stone SkateBoard");
        public static ProdutoMock Rolamento = new("Rolamento", dyego, "New Stone SkateBoard");
        
    }
}