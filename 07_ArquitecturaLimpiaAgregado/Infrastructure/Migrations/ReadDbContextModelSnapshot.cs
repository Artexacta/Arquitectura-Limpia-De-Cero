﻿// <auto-generated />
using System;
using Infrastructure.EF.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ReadDbContext))]
    partial class ReadDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.EF.ReadModels.AlumnoReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Alumnos", (string)null);
                });

            modelBuilder.Entity("Infrastructure.EF.ReadModels.MateriaReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CantidadAlumnos")
                        .HasColumnType("int");

                    b.Property<int>("Cupo")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Materias", (string)null);
                });

            modelBuilder.Entity("Infrastructure.EF.ReadModels.NotificacionReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Creado")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Mensaje")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.HasKey("Id");

                    b.ToTable("Notificaciones", (string)null);
                });

            modelBuilder.Entity("Infrastructure.EF.ReadModels.OrdenDeCobroReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AlumnoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MateriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Monto")
                        .HasPrecision(15, 4)
                        .HasColumnType("decimal(15,4)");

                    b.Property<bool>("Pagado")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AlumnoId");

                    b.HasIndex("MateriaId");

                    b.ToTable("OrdenesDeCobro", (string)null);
                });

            modelBuilder.Entity("Infrastructure.EF.ReadModels.RegistradoReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AlumnoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MateriaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AlumnoId");

                    b.HasIndex("MateriaId");

                    b.ToTable("Registrados", (string)null);
                });

            modelBuilder.Entity("Infrastructure.EF.ReadModels.OrdenDeCobroReadModel", b =>
                {
                    b.HasOne("Infrastructure.EF.ReadModels.AlumnoReadModel", "Alumno")
                        .WithMany()
                        .HasForeignKey("AlumnoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.EF.ReadModels.MateriaReadModel", "Materia")
                        .WithMany()
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alumno");

                    b.Navigation("Materia");
                });

            modelBuilder.Entity("Infrastructure.EF.ReadModels.RegistradoReadModel", b =>
                {
                    b.HasOne("Infrastructure.EF.ReadModels.AlumnoReadModel", "Alumno")
                        .WithMany()
                        .HasForeignKey("AlumnoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.EF.ReadModels.MateriaReadModel", "Materia")
                        .WithMany()
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alumno");

                    b.Navigation("Materia");
                });
#pragma warning restore 612, 618
        }
    }
}
