using Infrastructure.EF.ReadModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configurations.Read
{
    public class RegistradoReadEntityConfiguration : IEntityTypeConfiguration<RegistradoReadModel>
    {
        public void Configure(EntityTypeBuilder<RegistradoReadModel> builder)
        {
            builder.ToTable("Registrados");
        }
    }
}
