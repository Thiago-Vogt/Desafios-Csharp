namespace Desafio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GerenciarVendas gerenciador = new GerenciarVendas();

            Produto pao = new Produto("Pão", 10);
            Produto leite = new Produto("Leite", 5);
            Produto cafe = new Produto("Café", 7);
            try
            {
                PagamentoDinheiro pg = new PagamentoDinheiro(100);
                Venda vs = new VendaSimples(DateTime.Now, pg);
                vs.AdicionarItem(pao, 3);
                vs.AdicionarItem(leite, 2);
                gerenciador.adicionarVenda(vs);
            }
            catch (Exception ex) {
                Console.WriteLine($"Erro ao registrar venda: {ex.Message}");
            }
            try
            {
                PagamentoCartao pag = new PagamentoCartao("debito", "12345678912345");
                Cliente c1 = new Cliente("Joao", 0);
                Venda fidelizada = new VendaFidelizada(DateTime.Now, pag, c1);
                fidelizada.AdicionarItem(cafe, 2);
                fidelizada.AdicionarItem(leite, 1);
                gerenciador.adicionarVenda(fidelizada);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao registrar venda: {ex.Message}");
            }

        }
    }
}
