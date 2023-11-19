using CiudadanosSanos.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CiudadanosSanos.Models;
using Microsoft.EntityFrameworkCore;

namespace CiudadanosSanos.Pages.AtencionMedicas
{
    public class DeleteModel : PageModel
    {
		private readonly CiudadanosSanosContext _context;
		public DeleteModel(CiudadanosSanosContext context)
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
			else
			{
				AtencionMedica = atencionMedica;
			}
			return Page();

		}
		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null || _context.AtencionMedicas == null)
			{
				return NotFound();
			}

			var atencionMedica = await _context.AtencionMedicas.FindAsync(id);

			if (atencionMedica != null)
			{
				AtencionMedica = atencionMedica;
				_context.AtencionMedicas.Remove(AtencionMedica);
				await _context.SaveChangesAsync();
			}

			return RedirectToPage("./Index");
		}
	}
}
