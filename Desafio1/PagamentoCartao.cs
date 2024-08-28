using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Desafio1
{
    internal class PagamentoCartao : FormaPagamento
    {
        public string tipoCartao {  get; set; }

        public string numeroCartao{ get; set; }

        public PagamentoCartao(string tipo, string num)
        {
            tipoCartao = tipo;
            if (!ValidarNumeroCartao(num))
            {
                throw new CartaoInvalidoException("Número de cartão inválido. O número deve conter 16 dígitos.");
            }
            numeroCartao = num;
        }

        private bool ValidarNumeroCartao(string numeroCartao)
        {
            return numeroCartao.Length == 16;
        }

        public override void descricao(double valorTotal)
        {
             Console.WriteLine("Pagamento feito por cartão");
        }
    }
}
