using CiudadanosSanos.Data;
using CiudadanosSanos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CiudadanosSanos.Pages.Pacientes
{
	public class EditModel : PageModel
	{
		private readonly CiudadanosSanosContext _context;

		public EditModel(CiudadanosSanosContext context)
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
			Paciente = paciente;
			return Page();
		}
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}
			_context.Attach(Paciente).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!PacienteExists(Paciente.Id))
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
		private bool PacienteExists(int id)
		{
			return (_context.Pacientes?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
