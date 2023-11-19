using CiudadanosSanos.Data;
using CiudadanosSanos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CiudadanosSanos.Pages.AtencionMedicas
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
		public AtencionMedica AtencionMedica { get; set; } = default!;
		public async Task<IActionResult> OnPostAsync()
		{

			if (!ModelState.IsValid || _context.AtencionMedicas == null || AtencionMedica == null)
			{
				return Page();
			}
			_context.AtencionMedicas.Add(AtencionMedica);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
