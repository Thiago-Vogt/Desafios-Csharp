namespace Desafio2_padaria.Models
{
    public abstract class Pagamento
    {
        public decimal ValorTotal { get; set; }
        public abstract bool ProcessarPagamento();
    }
}
