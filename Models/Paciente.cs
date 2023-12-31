﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace CiudadanosSanos.Models
{
    public class Paciente
	{
		public int Id { get; set; } // Llave primaria 

		public string Name { get; set; }

		public int Edad {  get; set; }
		public string Sexo { get; set; }	

		public int Telefono { get; set; }

		public string? Description { get; set; }

		public ICollection<AtencionMedica>? AtencionMedicas { get; set; } // propiedad de navegacion
	}
}
