using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Desafio2_padaria.Data;
using Desafio2_padaria.Models;

namespace Desafio2_padaria.Pages.Vendas
{
    public class DetailsModel : PageModel
    {
        private readonly Desafio2_padariaContext _context;

        public DetailsModel(Desafio2_padariaContext context)
        {
            _context = context;
        }

        public Venda Venda { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Venda = await _context.Venda
                .Include(v => v.Cliente) 
                .Include(v => v.Produtos)
                .FirstOrDefaultAsync(m => m.VendaId == id);

            if (Venda == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
