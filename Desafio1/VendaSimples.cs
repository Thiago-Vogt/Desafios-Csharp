using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1
{
    internal class VendaSimples : Venda
    {
        public VendaSimples(DateTime data, FormaPagamento pagamento)
        : base(data, pagamento) { }

        public override void gerarCupomFiscal()
        {
            Console.WriteLine("Cupom Fiscal:");
            Console.WriteLine($"Data: {Data}");

            Console.WriteLine("Produtos:");
            foreach (var item in Itens)
            {
                Console.WriteLine($"{item.Produto.nomeProduto} - {item.Quantidade} x {item.Produto.precoProduto:C} = {item.Subtotal:C}");
            }

            Console.WriteLine($"Valor Total: {ValorTotal:C}");
            Pagamento.descricao(ValorTotal);
        }
    }
}
