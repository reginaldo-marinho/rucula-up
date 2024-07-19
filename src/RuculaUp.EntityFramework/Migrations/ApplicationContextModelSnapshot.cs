﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RuculaUp.EntityFramework;

#nullable disable

namespace RuculaX.EntityFramework.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RuculaX.EntityFramework.IntegranteModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<bool>("Batizado")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("DataDeNascimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<byte>("EstadoCivil")
                        .HasColumnType("smallint");

                    b.Property<string>("Ministerio")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("ServeNaIgreja")
                        .HasColumnType("boolean");

                    b.Property<string>("TelefoneCelular")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("IntegranteModel");
                });
#pragma warning restore 612, 618
        }
    }
}