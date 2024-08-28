using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1
{
    internal abstract class Venda
    {
        public DateTime Data { get; private set; }
        public List<ItensVenda> Itens { get; private set; } = new List<ItensVenda>();
        public double ValorTotal { get; private set; }
        public FormaPagamento Pagamento { get; private set; }

        protected Venda(DateTime data, FormaPagamento pagamento)
        {
            Data = data;
            Pagamento = pagamento;
        }

        public void AdicionarItem(Produto produto, int quantidade)
        {
            var itemVenda = new ItensVenda(produto, quantidade);
            Itens.Add(itemVenda);
            ValorTotal += itemVenda.Subtotal;
        }

        public abstract void gerarCupomFiscal();

    }
}
