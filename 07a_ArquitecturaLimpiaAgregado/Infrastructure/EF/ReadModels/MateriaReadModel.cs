﻿using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EF.ReadModels
{
    public class MateriaReadModel
    {
        public Guid Id { get; set; }

        [StringLength(250)]
        [Required]
        public string Nombre { get; private set; }

        [Required]
        public int Cupo { get; set; }

        [Required]
        public int CantidadAlumnos { get; private set; }

        public List<RegistradoReadModel> Registrados { get; set; }
    }
}
