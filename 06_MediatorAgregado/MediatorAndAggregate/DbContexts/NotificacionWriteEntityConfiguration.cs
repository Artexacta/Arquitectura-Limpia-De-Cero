using MediatorAndAggregate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediatorAndAggregate.DbContexts
{
    public class NotificacionWriteEntityConfiguration : IEntityTypeConfiguration<Notificacion>
    {
        public void Configure(EntityTypeBuilder<Notificacion> builder)
        {
            builder.ToTable("Notificaciones");
            builder.Ignore(x => x.DomainEvents);
            builder.Property(x => x.Email).HasMaxLength(200);
        }
    }
}
