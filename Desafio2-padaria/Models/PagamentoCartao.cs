namespace Desafio2_padaria.Models
{
    public class PagamentoCartao : Pagamento
    {
        public string NumeroCartao { get; set; }

        public PagamentoCartao(decimal valorTotal, string numeroCartao)
        {
            ValorTotal = valorTotal;
            NumeroCartao = numeroCartao;
        }

        public override bool ProcessarPagamento()
        {
            return NumeroCartao.Length == 16 && NumeroCartao.All(char.IsDigit);
        }

       
    }
}
