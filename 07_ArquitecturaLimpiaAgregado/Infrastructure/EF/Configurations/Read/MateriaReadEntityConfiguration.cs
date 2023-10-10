using Domain.Models;
using Infrastructure.EF.ReadModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configurations.Read
{
    public class MateriaReadEntityConfiguration : IEntityTypeConfiguration<MateriaReadModel>
    {
        public void Configure(EntityTypeBuilder<MateriaReadModel> builder)
        {
            builder.ToTable("Materias");
            builder.Ignore(x => x.Registrados);
            builder.Property(x => x.Nombre).HasMaxLength(200);
        }
    }
}
