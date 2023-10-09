namespace Application.ViewModels
{
    public class OrdenDeCobroViewModel
    {
        public Guid Id { get; set; }
        public AlumnoViewModel Alumno { get; set; }
        public Guid AlumnoId { get; private set; }
        public MateriaViewModel Materia { get; set; }
        public Guid MateriaId { get; private set; }
        public DateTime Fecha { get; private set; }
        public decimal Monto { get; private set; }
        public bool Pagado { get; private set; }
    }
}
