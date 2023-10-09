using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class MateriaViewModel
    {
        public Guid Id { get; set; }
        public string Nombre { get; private set; }
        public int Cupo { get; set; }
        public int CantidadAlumnos { get; private set; }
        public List<AlumnoViewModel> Registrados { get; set; }

        public MateriaViewModel()
        {
            Registrados = new List<AlumnoViewModel>();            
        }
    }
}
