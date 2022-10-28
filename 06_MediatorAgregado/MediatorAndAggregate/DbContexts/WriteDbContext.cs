using MediatorAndAggregate.Models;
using Microsoft.EntityFrameworkCore;

namespace MediatorAndAggregate.DbContexts
{
    public class WriteDbContext : DbContext
    {
        public virtual DbSet<Alumno> Alumnos { get; set; }
        public virtual DbSet<Materia> Materias { get; set; }
        public virtual DbSet<Registrado> Registrados { get; set; }
        public virtual DbSet<Notificacion> Notificaciones { get; set; }
        public virtual DbSet<OrdenDeCobro> OrdenesDeCobro { get; set; }

        public WriteDbContext() : base()
        {
            Console.WriteLine("Constructor vacio del contexto");
        }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
            
        }

        /// <summary>
        /// Esto es necesario solamente para poder hacer el migration. El normal es el que
        /// viene con parametros en el constructor y toma el connection string de appsettings.json
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.WriteLine("Configurando desde el onconfiguring");
            string connectionString = "Server=.;Database=AggregateDb;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var alumnoConfig = new AlumnoWriteEntityConfiguration();
            modelBuilder.ApplyConfiguration<Alumno>(alumnoConfig);
            var materiaConfig = new MateriaWriteEntityConfiguration();
            modelBuilder.ApplyConfiguration<Materia>(materiaConfig);
            var notificacionConfig = new NotificacionWriteEntityConfiguration();
            modelBuilder.ApplyConfiguration<Notificacion>(notificacionConfig);
            var ordendecobroConfig = new OrdenDeCobroWriteEntityConfiguration();
            modelBuilder.ApplyConfiguration<OrdenDeCobro>(ordendecobroConfig);
            var registradoConfig = new RegistradoWriteEntityConfiguration();
            modelBuilder.ApplyConfiguration<Registrado>(registradoConfig);
        }
    }
}
