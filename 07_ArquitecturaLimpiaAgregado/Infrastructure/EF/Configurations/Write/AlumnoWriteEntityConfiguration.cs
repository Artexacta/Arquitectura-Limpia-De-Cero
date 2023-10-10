using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configurations.Write
{
    public class AlumnoWriteEntityConfiguration : IEntityTypeConfiguration<Alumno>
    {
        public void Configure(EntityTypeBuilder<Alumno> builder)
        {
            builder.Ignore(x => x.DomainEvents);
            builder.Property(x => x.Nombre).HasMaxLength(200);
        }
    }
}
