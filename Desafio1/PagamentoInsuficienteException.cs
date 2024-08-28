using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1
{
    internal class PagamentoInsuficienteException : Exception
    {
        public PagamentoInsuficienteException(string message) : base(message) { }
    }
}
