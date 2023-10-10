using Infrastructure.EF.Configurations.Read;
using Infrastructure.EF.ReadModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Infrastructure.EF.DbContexts
{
    public class ReadDbContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly DbContextOptions<ReadDbContext> _options;

        public virtual DbSet<AlumnoReadModel> Alumnos { get; set; }
        public virtual DbSet<MateriaReadModel> Materias { get; set; }
        public virtual DbSet<RegistradoReadModel> Registrados { get; set; }
        public virtual DbSet<NotificacionReadModel> Notificaciones { get; set; }
        public virtual DbSet<OrdenDeCobroReadModel> OrdenesDeCobro { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options,
            ILoggerFactory loggerFactory) : base(options)
        {
            _options = options;
            _loggerFactory = loggerFactory;
        }

        public DbContextOptions<ReadDbContext> OptionsProperty
        {
            get { return _options; }
        }

        public ILoggerFactory LoggerFactoryProperty
        {
            get { return _loggerFactory; }
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(c => c.Log((RelationalEventId.CommandExecuting, LogLevel.Debug)));
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var alumnoConfig = new AlumnoReadEntityConfiguration();
            modelBuilder.ApplyConfiguration<AlumnoReadModel>(alumnoConfig);
            var materiaConfig = new MateriaReadEntityConfiguration();
            modelBuilder.ApplyConfiguration<MateriaReadModel>(materiaConfig);
            var notificacionConfig = new NotificacionReadEntityConfiguration();
            modelBuilder.ApplyConfiguration<NotificacionReadModel>(notificacionConfig);
            var ordendecobroConfig = new OrdenDeCobroReadEntityConfiguration();
            modelBuilder.ApplyConfiguration<OrdenDeCobroReadModel>(ordendecobroConfig);
            var registradoConfig = new RegistradoReadEntityConfiguration();
            modelBuilder.ApplyConfiguration<RegistradoReadModel>(registradoConfig);
        }
    }
}
