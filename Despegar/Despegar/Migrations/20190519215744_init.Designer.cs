﻿// <auto-generated />
using System;
using Despegar.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Despegar.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190519215744_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Despegar.Entity.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantidadPersonas");

                    b.Property<int>("CuartoId");

                    b.Property<int>("DiasReserva");

                    b.Property<DateTime>("FechaReserva");

                    b.Property<string>("Hotel")
                        .IsRequired();

                    b.Property<int>("IdentificacionCliente");

                    b.Property<string>("NombreCliente")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}
