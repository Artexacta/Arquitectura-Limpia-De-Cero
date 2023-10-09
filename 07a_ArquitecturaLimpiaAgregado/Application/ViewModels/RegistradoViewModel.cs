using Infrastructure.EF.ReadModels;

namespace Application.ViewModels
{
    public class RegistradoViewModel
    {
        public Guid Id { get; set; }
        public AlumnoReadModel Alumno { get; set; }
        public Guid AlumnoId { get; set; }
        public MateriaReadModel Materia { get; set; }
        public Guid MateriaId { get; set; }
    }
}
