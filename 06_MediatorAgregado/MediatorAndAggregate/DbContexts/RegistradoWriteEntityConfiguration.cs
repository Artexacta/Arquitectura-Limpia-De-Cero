using MediatorAndAggregate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediatorAndAggregate.DbContexts
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
