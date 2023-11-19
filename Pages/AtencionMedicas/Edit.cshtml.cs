using CiudadanosSanos.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CiudadanosSanos.Models;
using Microsoft.EntityFrameworkCore;

namespace CiudadanosSanos.Pages.AtencionMedicas
{
    public class EditModel : PageModel
    {
		private readonly CiudadanosSanosContext _context;
		public EditModel(CiudadanosSanosContext context)
		{
			_context = context;
		}
		[BindProperty]
		public AtencionMedica AtencionMedica { get; set; } = default!;
		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.AtencionMedicas == null)
			{
				return NotFound();
			}

			var atencionMedica = await _context.AtencionMedicas.FirstOrDefaultAsync(m => m.Id == id);
			if (atencionMedica == null)
			{
				return NotFound();
			}
			AtencionMedica = atencionMedica;
			return Page();
		}
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}
			_context.Attach(AtencionMedica).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!AtencionMedicaExists(AtencionMedica.Id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}
			return RedirectToPage("./Index");
		}
		private bool AtencionMedicaExists(int id)
		{
			return (_context.AtencionMedicas?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
