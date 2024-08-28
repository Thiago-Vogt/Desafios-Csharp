using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1
{
    class CartaoInvalidoException : Exception
    {
        public CartaoInvalidoException(string message) : base(message) { }
    }
}
