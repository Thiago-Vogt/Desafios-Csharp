namespace Desafio2_padaria.Models
{
    public class PagamentoDinheiro : Pagamento
    {
        public decimal ValorPago { get; set; }

        public PagamentoDinheiro(decimal valorTotal, decimal valorPago)
        {
            ValorTotal = valorTotal;
            ValorPago = valorPago;
        }

        public decimal CalcularTroco()
        {
            return ValorPago - ValorTotal;
        }

        public override bool ProcessarPagamento()
        {
            if (ValorPago >= ValorTotal)
            {
                Console.WriteLine($"Pagamento realizado. Troco: R$ {CalcularTroco():F2}");
                return true;
            }
            else
            {
                Console.WriteLine("Valor pago insuficiente.");
                return false;
            }
        }
    }
}
