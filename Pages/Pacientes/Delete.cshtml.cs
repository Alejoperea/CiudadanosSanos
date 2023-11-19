using CiudadanosSanos.Data;
using CiudadanosSanos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CiudadanosSanos.Pages.Pacientes
{
    public class DeleteModel : PageModel
    {
		private readonly CiudadanosSanosContext _context;

		public DeleteModel(CiudadanosSanosContext context)
		{
			_context = context;
		}
		[BindProperty]
		public Paciente Paciente { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Pacientes == null)
			{
				return NotFound();
			}
			var paciente = await _context.Pacientes.FirstOrDefaultAsync(m => m.Id == id);

			if (paciente == null)
			{
				return NotFound();
			}
			else
			{
				Paciente = paciente;
			}
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null || _context.Pacientes == null)
			{
				return NotFound();
			}

			var paciente = await _context.Pacientes.FindAsync(id);

			if (paciente != null)
			{
				Paciente = paciente;
				_context.Pacientes.Remove(Paciente);
				await _context.SaveChangesAsync();
			}

			return RedirectToPage("./Index");
		}
	}
}
