using CiudadanosSanos.Data;
using CiudadanosSanos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CiudadanosSanos.Pages.Pacientes
{
    [Authorize]
    public class IndexModel : PageModel
    {
		private readonly CiudadanosSanosContext _context;
		public IndexModel(CiudadanosSanosContext context)
		{

			_context = context;
		}
		public IList<Paciente> Pacientes { get; set; } = default!;

		public async Task OnGetAsync()
		{
			if (_context.Pacientes != null)
			{
				Pacientes = await _context.Pacientes.ToListAsync();
			}
		}
	}
}
