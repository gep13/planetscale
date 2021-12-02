using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Planetscale.Data;
using planetscale.Modals;

namespace planetscale.Pages.CustomerInformation
{
    public class DeleteModel : PageModel
    {
        private readonly Planetscale.Data.PlanetscaleContext _context;

        public DeleteModel(Planetscale.Data.PlanetscaleContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CustomerInformationModal CustomerInformation { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CustomerInformation = await _context.CustomerInformation.FirstOrDefaultAsync(m => m.Id == id);

            if (CustomerInformation == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CustomerInformation = await _context.CustomerInformation.FindAsync(id);

            if (CustomerInformation != null)
            {
                _context.CustomerInformation.Remove(CustomerInformation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
