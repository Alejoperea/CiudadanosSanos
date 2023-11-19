using CiudadanosSanos.Data;
using CiudadanosSanos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CiudadanosSanos.Pages.AtencionMedicas
{
	public class IndexModel : PageModel
	{
		private readonly CiudadanosSanosContext _context;

		public IndexModel(CiudadanosSanosContext context)
		{
			_context = context;
		}
		public IList<AtencionMedica> AtencionMedicas { get; set; } = default!;
		public async Task OnGetAsync()
		{
			if (_context.AtencionMedicas != null)
			{
				AtencionMedicas = await _context.AtencionMedicas.ToListAsync();

			}
		}
	}
}
