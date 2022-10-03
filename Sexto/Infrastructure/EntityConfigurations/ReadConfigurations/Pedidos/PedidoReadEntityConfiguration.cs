﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Application.Dto.Pedidos;

namespace Infrastructure.EntityConfigurations.ReadConfigurations.Pedidos
{
    public class PedidoReadEntityConfiguration : IEntityTypeConfiguration<PedidoDto>
    {
        public void Configure(EntityTypeBuilder<PedidoDto> builder)
        {
            builder.ToTable("Pedidos");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NombreCliente)
                .HasMaxLength(250);

            builder.Property(x => x.Descuento)
                .HasColumnType("decimal(18,4)");
        }
    }
}
