using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Desafio2_padaria.Data;
using Desafio2_padaria.Models;

namespace Desafio2_padaria.Pages.Clientes
{
    public class DetailsModel : PageModel
    {
        private readonly Desafio2_padaria.Data.Desafio2_padariaContext _context;

        public DetailsModel(Desafio2_padaria.Data.Desafio2_padariaContext context)
        {
            _context = context;
        }

        public Cliente Cliente { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FirstOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }
            else
            {
                Cliente = cliente;
            }
            return Page();
        }
    }
}
