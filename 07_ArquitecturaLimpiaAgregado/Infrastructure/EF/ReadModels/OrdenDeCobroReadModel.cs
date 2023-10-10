namespace Infrastructure.EF.ReadModels
{
    public class OrdenDeCobroReadModel
    {
        public Guid Id { get; private set; }
        public AlumnoReadModel Alumno { get; set; }
        public Guid AlumnoId { get; private set; }
        public MateriaReadModel Materia { get; set; }
        public Guid MateriaId { get; private set; }
        public DateTime Fecha { get; private set; }
        public decimal Monto { get; private set; }
        public bool Pagado { get; private set; }
    }
}
