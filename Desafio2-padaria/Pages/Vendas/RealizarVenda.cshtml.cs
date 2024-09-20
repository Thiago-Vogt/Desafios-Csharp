using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Desafio2_padaria.Data;
using Desafio2_padaria.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Desafio2_padaria.Pages.Vendas
{
    public class RealizarVendaModel : PageModel
    {
        private readonly Desafio2_padaria.Data.Desafio2_padariaContext _context;
        private readonly HttpClient _httpClient;

        public RealizarVendaModel(Desafio2_padaria.Data.Desafio2_padariaContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }

        // Propriedades para armazenar as opções de cliente, produtos e pagamento
        public SelectList Clientes { get; set; }
        public List<SelectListItem> Produtos { get; set; }
        public SelectList FormasPagamento { get; set; }

        [BindProperty]
        public Venda Venda { get; set; } = default!;

        [BindProperty]
        public List<int> ProdutosSelecionados { get; set; } = new List<int>(); 

        [BindProperty]
        public string FormaPagamentoSelecionada { get; set; }

        [BindProperty]
        public decimal? ValorPago { get; set; } 

        [BindProperty]
        public string NumeroCartao { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            // Listar os clientes
            Clientes = new SelectList(await _context.Cliente.ToListAsync(), "ClienteId", "Nome");

            // Listar os produtos
            Produtos = await _context.Produto
                .Select(p => new SelectListItem
                {
                    Value = p.ProdutoId.ToString(),
                    Text = $"{p.Descricao} - R$ {p.Preco:F2}"
                })
                .ToListAsync();

            // Definir as opções de forma de pagamento
            FormasPagamento = new SelectList(new List<string> { "Dinheiro", "Cartão de Crédito", "Cartão de Débito" });

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Adicionar os produtos selecionados à venda
            Venda.Produtos = new List<Produto>();

            foreach (var produtoId in ProdutosSelecionados)
            {
                var produto = await _context.Produto.FindAsync(produtoId);
                if (produto != null)
                {
                    Venda.Produtos.Add(produto);
                    Venda.ValorTotal += produto.Preco;
                }
            }

            // Verificar se produtos foram selecionados
            if (Venda.Produtos == null || Venda.Produtos.Count == 0)
            {
                ModelState.AddModelError(string.Empty, "Selecione pelo menos um produto.");
                return Page();
            }

            // Definir a forma de pagamento
            Venda.FormaPagamento = FormaPagamentoSelecionada;

            // Registrar a data da venda
            Venda.Data = DateTime.Now;


            // Adicionar a venda ao banco de dados
            _context.Venda.Add(Venda);
            await _context.SaveChangesAsync();

            if (Venda.ClienteId.HasValue)
            {
                int pontosParaAdicionar = CalcularPontos(Venda.ValorTotal);

                var clienteId = Venda.ClienteId;

                try
                {
                    string apiUrl = $"http://localhost:5147/api/ClientePontos/{clienteId}/adicionar-pontos/{pontosParaAdicionar}";

                    var response = await _httpClient.PostAsync(apiUrl, null);

                    if (response.IsSuccessStatusCode)
                    {
                        var message = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(message);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Erro ao adicionar os pontos.");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Erro ao consumir a API: {ex.Message}");
                }
            }

            return RedirectToPage("./Index");
        }

        private int CalcularPontos(decimal valorTotal)
        {
            return (int)Math.Floor(valorTotal / 2);
        }

    }
}
