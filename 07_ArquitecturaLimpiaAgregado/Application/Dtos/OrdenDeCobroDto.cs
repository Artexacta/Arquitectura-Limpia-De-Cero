namespace Application.Dtos
{
    public class OrdenDeCobroDto
    {
        public Guid Id { get; set; }
        public AlumnoDto Alumno { get; set; }
        public Guid AlumnoId { get; private set; }
        public MateriaDto Materia { get; set; }
        public Guid MateriaId { get; private set; }
        public DateTime Fecha { get; private set; }
        public decimal Monto { get; private set; }
        public bool Pagado { get; private set; }
    }
}
