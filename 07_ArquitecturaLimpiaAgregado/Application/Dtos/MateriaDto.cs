using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class MateriaDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; private set; }
        public int Cupo { get; set; }
        public int CantidadAlumnos { get; private set; }
        public List<AlumnoDto> AlumnosRegistrados { get; set; }

        public MateriaDto()
        {
            AlumnosRegistrados = new List<AlumnoDto>();            
        }
    }
}
