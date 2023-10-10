using Infrastructure.EF.ReadModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configurations.Read
{
    public class OrdenDeCobroReadEntityConfiguration : IEntityTypeConfiguration<OrdenDeCobroReadModel>
    {
        public void Configure(EntityTypeBuilder<OrdenDeCobroReadModel> builder)
        {
            builder.ToTable("OrdenesDeCobro");
            builder.Property(x => x.Monto).HasPrecision(15, 4);
        }
    }
}
