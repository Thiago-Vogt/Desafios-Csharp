using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1
{
    internal class GerenciarVendas
    {
        public List<Venda> vendas = new List<Venda>();

        public void adicionarVenda(Venda venda)
        {
            try
            {
                vendas.Add(venda);
                venda.gerarCupomFiscal();
            }
            catch (PagamentoInsuficienteException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            catch (CartaoInvalidoException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }
        }
    }
}
