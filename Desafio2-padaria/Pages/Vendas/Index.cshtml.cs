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
    public class IndexModel : PageModel
    {
        private readonly Desafio2_padaria.Data.Desafio2_padariaContext _context;

        public IndexModel(Desafio2_padaria.Data.Desafio2_padariaContext context)
        {
            _context = context;
        }

        public IList<Venda> Venda { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Venda = await _context.Venda
                .Include(v => v.Cliente).ToListAsync();
        }
    }
}
