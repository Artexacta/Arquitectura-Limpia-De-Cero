using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configurations.Write
{
    public class RegistradoWriteEntityConfiguration : IEntityTypeConfiguration<Registrado>
    {
        public void Configure(EntityTypeBuilder<Registrado> builder)
        {
            builder.ToTable("Registrados");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
