using MediatorAndAggregate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediatorAndAggregate.DbContexts
{
    public class OrdenDeCobroWriteEntityConfiguration : IEntityTypeConfiguration<OrdenDeCobro>
    {
        public void Configure(EntityTypeBuilder<OrdenDeCobro> builder)
        {
            builder.ToTable("OrdenesDeCobro");
            builder.Ignore(x => x.DomainEvents);
            builder.Property(x => x.Monto).HasPrecision(15, 4);
        }
    }
}
