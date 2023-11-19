namespace CiudadanosSanos.Models
{
	public class AtencionMedica
	{
		//[Key] -> Anotacion si la propiedad no se llama Id ejemplo ProductId
		public int Id { get; set; } //Seria la llave primaria 
		public string NameMedico { get; set; }

		public string NamePaciente { get; set; }

		public string Fecha { get; set; }

		public int PacienteId { get; set; } // sera la llave foranea 

		public ICollection<Paciente>? Pacientes { get; set; } = default!;    // Propiedad de navegacion 

	}
}
