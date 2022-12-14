using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace domain.CatalogoDeProdutos.Excessoes
{
    public class ProdutoException : Exception
    {
        public ProdutoException()
        {
        }

        public ProdutoException(string? message) : base(message)
        {
        }

        public ProdutoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ProdutoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}