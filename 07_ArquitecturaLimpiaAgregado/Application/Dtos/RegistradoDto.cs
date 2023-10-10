using Infrastructure.EF.ReadModels;

namespace Application.Dtos
{
    public class RegistradoDto
    {
        public Guid Id { get; set; }
        public AlumnoDto Alumno { get; set; }
        public Guid AlumnoId { get; set; }
        public MateriaReadModel Materia { get; set; }
        public Guid MateriaId { get; set; }
    }
}
