using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Desafio2_padaria.Data;
using Desafio2_padaria.Models;

namespace Desafio2_padaria.Pages.Produtos
{
    public class CreateModel : PageModel
    {
        private readonly Desafio2_padaria.Data.Desafio2_padariaContext _context;

        public CreateModel(Desafio2_padaria.Data.Desafio2_padariaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Produto Produto { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            _context.Produto.Add(Produto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
