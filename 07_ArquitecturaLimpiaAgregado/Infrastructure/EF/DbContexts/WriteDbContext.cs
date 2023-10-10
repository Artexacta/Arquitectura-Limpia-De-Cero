using Domain.Models;
using Infrastructure.EF.Configurations.Write;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Infrastructure.EF.DbContexts
{
    public class WriteDbContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly DbContextOptions<WriteDbContext> _options;

        public virtual DbSet<Alumno> Alumnos { get; set; }
        public virtual DbSet<Materia> Materias { get; set; }
        public virtual DbSet<Registrado> Registrados { get; set; }
        public virtual DbSet<Notificacion> Notificaciones { get; set; }
        public virtual DbSet<OrdenDeCobro> OrdenesDeCobro { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options,
            ILoggerFactory loggerFactory) : base(options)
        {
            _options = options;
            _loggerFactory = loggerFactory;

        }

        public ILoggerFactory LoggerFactoryProperty
        {
            get { return _loggerFactory; }
        }

        public DbContextOptions<WriteDbContext> OptionsProperty
        {
            get { return _options; }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(c => c.Log((RelationalEventId.CommandExecuting, LogLevel.Debug)));
            optionsBuilder.EnableSensitiveDataLogging();
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
