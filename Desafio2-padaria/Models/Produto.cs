namespace Desafio2_padaria.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }

        public List<Venda> Vendas { get; set; }
    }
}
