using MediatR;

namespace Application.UseCases.Commands
{
    public class NotificarCobroCommand : IRequest<bool>
    {
        public Guid AlumnoId { get; set; }
        public string NombreAlumno { get; set; }
        public Guid MateriaId { get; set; }
        public string NombreMateria { get; set; }

        public NotificarCobroCommand(Guid alumnoId, string nombreAlumno, 
            Guid materiaId, string nombreMateria)
        {
            AlumnoId = alumnoId;
            NombreAlumno = nombreAlumno;
            MateriaId = materiaId;
            NombreMateria = nombreMateria;
        }
    }
}
