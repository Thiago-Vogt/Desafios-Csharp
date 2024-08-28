using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1
{
    internal class VendaFidelizada : Venda
    {
        public Cliente Cliente { get; set; }

        public VendaFidelizada(DateTime data, FormaPagamento pagamento, Cliente cliente)
        : base(data, pagamento)
        {
            Cliente = cliente;
        }

        public void calcularPontos()
        {
            Cliente.adicionarPontos((int)ValorTotal / 2);
        }
        public override void gerarCupomFiscal()
        {
            calcularPontos();

            Console.WriteLine("\nCupom Fiscal - Cliente Fidelizado:");
            Console.WriteLine($"Data: {Data}");

            Console.WriteLine("Produtos:");
            foreach (var item in Itens)
            {
                Console.WriteLine($"{item.Produto.nomeProduto} - {item.Quantidade} x {item.Produto.precoProduto:C} = {item.Subtotal:C}");
            }

            Console.WriteLine($"Valor Total: {ValorTotal:C}");
            Pagamento.descricao(ValorTotal);
            Console.WriteLine($"Cliente: {Cliente.Nome}");
            Console.WriteLine($"Pontos Acumulados: {Cliente.Pontos}");
        }
    }
}
