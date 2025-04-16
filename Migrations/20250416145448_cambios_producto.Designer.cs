﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Prueba.Shared.Data;

#nullable disable

namespace prueba_backend.Migrations
{
    [DbContext(typeof(ProductosDbContext))]
    [Migration("20250416145448_cambios_producto")]
    partial class cambios_producto
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Prueba.Domain.Entities.Bodega", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Bodegas");
                });

            modelBuilder.Entity("Prueba.Domain.Entities.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("BodegaId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("FechaIngreso")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.Property<double>("Precio")
                        .HasColumnType("double precision");

                    b.Property<int>("Stock")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BodegaId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Prueba.Domain.Entities.Producto", b =>
                {
                    b.HasOne("Prueba.Domain.Entities.Bodega", null)
                        .WithMany("Producto")
                        .HasForeignKey("BodegaId");
                });

            modelBuilder.Entity("Prueba.Domain.Entities.Bodega", b =>
                {
                    b.Navigation("Producto");
                });
#pragma warning restore 612, 618
        }
    }
}
