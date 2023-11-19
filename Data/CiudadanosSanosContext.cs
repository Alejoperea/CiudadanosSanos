using CiudadanosSanos.Models;
using Microsoft.EntityFrameworkCore;

namespace CiudadanosSanos.Data
{
	public class CiudadanosSanosContext : DbContext
	{
		public CiudadanosSanosContext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<AtencionMedica> AtencionMedicas { get; set; }
		public DbSet<Paciente> Pacientes { get; set; }


		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	optionsBuilder.UseSqlServer(
		//		"Server=(localdb)\\mssqllocaldb;Database=CiudadanosSanos;Trusted_Connection=True;");
		//}
	}
}
