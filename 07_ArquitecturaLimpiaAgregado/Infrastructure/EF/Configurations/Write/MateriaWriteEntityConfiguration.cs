using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configurations.Write
{
    public class MateriaWriteEntityConfiguration : IEntityTypeConfiguration<Materia>
    {
        public void Configure(EntityTypeBuilder<Materia> builder)
        {
            builder.Ignore(x => x.DomainEvents);            
            builder.Property(x => x.Nombre).HasMaxLength(200);
        }
    }
}
