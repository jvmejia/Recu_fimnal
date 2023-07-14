﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoLogin.Models;

#nullable disable

namespace ProyectoLogin.Migrations
{
    [DbContext(typeof(DbpruebaContext))]
    partial class DbpruebaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProyectoLogin.Models.Activo", b =>
                {
                    b.Property<int>("IdActivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdActivo"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estatus")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdActivo");

                    b.ToTable("Activos");
                });

            modelBuilder.Entity("ProyectoLogin.Models.ActivoEmpleado", b =>
                {
                    b.Property<int>("IdActivoEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdActivoEmpleado"));

                    b.Property<DateTime>("FechaDeAsignacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaDeEntrega")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaDeLiberacion")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FkActivo")
                        .HasColumnType("int");

                    b.Property<int?>("FkEmpleado")
                        .HasColumnType("int");

                    b.HasKey("IdActivoEmpleado");

                    b.HasIndex("FkActivo");

                    b.HasIndex("FkEmpleado");

                    b.ToTable("ActivoEmpleados");
                });

            modelBuilder.Entity("ProyectoLogin.Models.Empleado", b =>
                {
                    b.Property<int>("IdEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEmpleado"));

                    b.Property<bool>("Estatus")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumEmpleado")
                        .HasColumnType("int");

                    b.HasKey("IdEmpleado");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("ProyectoLogin.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Clave")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Correo")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NombreCompleto")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdUsuario")
                        .HasName("PK__USUARIO__5B65BF97D1F49851");

                    b.ToTable("USUARIO", (string)null);
                });

            modelBuilder.Entity("ProyectoLogin.Models.ActivoEmpleado", b =>
                {
                    b.HasOne("ProyectoLogin.Models.Activo", "Activo")
                        .WithMany()
                        .HasForeignKey("FkActivo");

                    b.HasOne("ProyectoLogin.Models.Empleado", "Empleado")
                        .WithMany()
                        .HasForeignKey("FkEmpleado");

                    b.Navigation("Activo");

                    b.Navigation("Empleado");
                });
#pragma warning restore 612, 618
        }
    }
}
