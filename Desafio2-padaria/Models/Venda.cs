namespace Desafio2_padaria.Models
{
    public class Venda
    {
        public int VendaId { get; set; }
        public DateTime Data { get; set; }
        public int? ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public string FormaPagamento { get; set; }
        public decimal ValorTotal { get; set; }

        public List<Produto> Produtos { get; set; }
    }
}
