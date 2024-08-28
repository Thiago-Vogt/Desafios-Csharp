using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1
{
    internal class PagamentoDinheiro : FormaPagamento
    {
        public PagamentoDinheiro(double valor)
        {
            this.valorRecebido = valor;
        }
        public double valorRecebido {  get; set; }

        public override void descricao(double valorTotal)
        {
            if (valorRecebido < valorTotal)
            {
                throw new PagamentoInsuficienteException("Valor recebido é insuficiente para cobrir o valor total da compra.");
            }

            double troco = valorRecebido - valorTotal;
            Console.WriteLine($"Forma de Pagamento: Dinheiro");
            Console.WriteLine($"Valor Recebido: {valorRecebido:C}");
            Console.WriteLine($"Troco: {troco:C}");
        }
    }
}
