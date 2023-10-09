using Infrastructure.EF.ReadModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configurations.Read
{
    public class NotificacionReadEntityConfiguration : IEntityTypeConfiguration<NotificacionReadModel>
    {
        public void Configure(EntityTypeBuilder<NotificacionReadModel> builder)
        {
            builder.ToTable("Notificaciones");
            builder.Property(x => x.Email).HasMaxLength(200);
            builder.Property(x => x.Mensaje).HasMaxLength(4000);
        }
    }
}
