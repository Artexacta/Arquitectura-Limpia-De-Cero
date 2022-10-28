using MediatorAndAggregate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediatorAndAggregate.DbContexts
{
    public class AlumnoWriteEntityConfiguration : IEntityTypeConfiguration<Alumno>
    {
        public void Configure(EntityTypeBuilder<Alumno> builder)
        {
            builder.ToTable("Alumnos");
            builder.Ignore(x => x.DomainEvents);
            builder.Property(x => x.Nombre).HasMaxLength(200);
        }
    }
}
