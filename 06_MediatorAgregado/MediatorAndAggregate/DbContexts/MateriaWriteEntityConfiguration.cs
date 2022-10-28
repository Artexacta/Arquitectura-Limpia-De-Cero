using MediatorAndAggregate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediatorAndAggregate.DbContexts
{
    public class MateriaWriteEntityConfiguration : IEntityTypeConfiguration<Materia>
    {
        public void Configure(EntityTypeBuilder<Materia> builder)
        {
            builder.ToTable("Materias");
            builder.Ignore(x => x.DomainEvents);
            builder.Ignore(x => x.Registrados);
            builder.Property(x => x.Nombre).HasMaxLength(200);
        }
    }
}
