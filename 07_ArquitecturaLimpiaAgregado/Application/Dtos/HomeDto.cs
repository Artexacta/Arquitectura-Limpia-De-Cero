using Infrastructure.EF.ReadModels;

namespace Application.Dtos
{
    public class HomeDto
    {
        public List<AlumnoDto>  Alumnos { get; set; }
        public List<MateriaDto> Materias { get; set; }
        public List<NotificacionDto> Notificaciones { get; set; }
        public List<OrdenDeCobroDto> OrdenesDeCobro { get; set; }

        public HomeDto()
        {
            Alumnos = new List<AlumnoDto>();
            Materias = new List<MateriaDto>();
            Notificaciones = new List<NotificacionDto>();
            OrdenesDeCobro = new List<OrdenDeCobroDto>();
        }
    }
}
