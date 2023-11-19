using CiudadanosSanos.Data;
using CiudadanosSanos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CiudadanosSanos.Pages.Pacientes
{
	public class CreateModel : PageModel
	{
		private readonly CiudadanosSanosContext _context;

		public CreateModel(CiudadanosSanosContext context)
		{
			_context = context;
		}
		public IActionResult OnGet()
		{
			return Page();
		}
		[BindProperty]

		public Paciente Paciente { get; set; } = default!;

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.Pacientes == null || Paciente == null)
			{
				return Page();
			}
			_context.Pacientes.Add(Paciente);
			await _context.SaveChangesAsync();
			return RedirectToPage("./Index");
		}

	}
}
