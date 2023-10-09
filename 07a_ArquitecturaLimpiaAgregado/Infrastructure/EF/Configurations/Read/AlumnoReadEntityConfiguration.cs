using Infrastructure.EF.ReadModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configurations.Read
{
    public class AlumnoReadEntityConfiguration : IEntityTypeConfiguration<AlumnoReadModel>
    {
        public void Configure(EntityTypeBuilder<AlumnoReadModel> builder)
        {
            builder.ToTable("Alumnos");
            builder.Property(x => x.Nombre).HasMaxLength(200);
        }
    }
}
