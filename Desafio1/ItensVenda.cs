using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1
{
    internal class ItensVenda
    {
        public Produto Produto { get; private set; }
        public int Quantidade { get; private set; }
        public double Subtotal => Produto.precoProduto * Quantidade;

        public ItensVenda(Produto produto, int quantidade)
        {
            Produto = produto;
            Quantidade = quantidade;
        }
    }
}
