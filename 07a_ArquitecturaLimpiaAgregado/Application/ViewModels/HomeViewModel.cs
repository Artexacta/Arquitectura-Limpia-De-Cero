using Infrastructure.EF.ReadModels;

namespace Application.ViewModels
{
    public class HomeViewModel
    {
        public List<AlumnoViewModel>  Alumnos { get; set; }
        public List<MateriaViewModel> Materias { get; set; }

        public HomeViewModel()
        {
            Alumnos = new List<AlumnoViewModel>();
            Materias = new List<MateriaViewModel>();
        }
    }
}
