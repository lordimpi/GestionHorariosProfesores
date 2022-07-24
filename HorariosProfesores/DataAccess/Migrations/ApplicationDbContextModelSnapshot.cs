﻿// <auto-generated />
using System;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DataAccess.Data.Entities.Competencia", b =>
                {
                    b.Property<int>("Competencia_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Competencia_Id"), 1L, 1);

                    b.Property<string>("Competencia_Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("Programa_Id")
                        .HasColumnType("int");

                    b.HasKey("Competencia_Id");

                    b.HasIndex("Programa_Id");

                    b.HasIndex("Competencia_Nombre", "Programa_Id")
                        .IsUnique()
                        .HasFilter("[Programa_Id] IS NOT NULL");

                    b.ToTable("Competencias");
                });

            modelBuilder.Entity("DataAccess.Data.Entities.Docente", b =>
                {
                    b.Property<int>("Docente_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Docente_Id"), 1L, 1);

                    b.Property<string>("Docente_Apellidos")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Docente_Area")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Docente_Identificacion")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Docente_Nombres")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Docente_Tipo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Docente_TipoContrato")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Docente_TipoIdentificacion")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Docente_Id");

                    b.HasIndex("Docente_Identificacion")
                        .IsUnique();

                    b.ToTable("Docentes");
                });

            modelBuilder.Entity("DataAccess.Data.Entities.PeriodoAcademico", b =>
                {
                    b.Property<int>("Periodo_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Periodo_Id"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Periodo_FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Periodo_FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Periodo_Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Periodo_Id");

                    b.HasIndex("Periodo_Nombre")
                        .IsUnique();

                    b.ToTable("PeriodoAcademicos");
                });

            modelBuilder.Entity("DataAccess.Data.Entities.PeriodoAcademicoPrograma", b =>
                {
                    b.Property<int>("PeriodoAcademicoId")
                        .HasColumnType("int");

                    b.Property<int>("ProgramaId")
                        .HasColumnType("int");

                    b.HasKey("PeriodoAcademicoId", "ProgramaId");

                    b.HasIndex("ProgramaId");

                    b.ToTable("PeriodoAcademicoProgramas");
                });

            modelBuilder.Entity("DataAccess.Data.Entities.Programa", b =>
                {
                    b.Property<int>("Programa_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Programa_Id"), 1L, 1);

                    b.Property<bool>("IsActivo")
                        .HasColumnType("bit");

                    b.Property<int?>("PeriodoAcademicoPeriodo_Id")
                        .HasColumnType("int");

                    b.Property<string>("Programa_Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Programa_Id");

                    b.HasIndex("PeriodoAcademicoPeriodo_Id");

                    b.HasIndex("Programa_Nombre")
                        .IsUnique();

                    b.ToTable("Programas");
                });

            modelBuilder.Entity("DataAccess.Data.Entities.Competencia", b =>
                {
                    b.HasOne("DataAccess.Data.Entities.Programa", "Programa")
                        .WithMany("Competencias")
                        .HasForeignKey("Programa_Id");

                    b.Navigation("Programa");
                });

            modelBuilder.Entity("DataAccess.Data.Entities.PeriodoAcademicoPrograma", b =>
                {
                    b.HasOne("DataAccess.Data.Entities.PeriodoAcademico", "PeriodoAcademico")
                        .WithMany("PeriodoAcademicoProgramas")
                        .HasForeignKey("PeriodoAcademicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Data.Entities.Programa", "Programa")
                        .WithMany("PeriodoAcademicoProgramas")
                        .HasForeignKey("ProgramaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PeriodoAcademico");

                    b.Navigation("Programa");
                });

            modelBuilder.Entity("DataAccess.Data.Entities.Programa", b =>
                {
                    b.HasOne("DataAccess.Data.Entities.PeriodoAcademico", null)
                        .WithMany("Programas")
                        .HasForeignKey("PeriodoAcademicoPeriodo_Id");
                });

            modelBuilder.Entity("DataAccess.Data.Entities.PeriodoAcademico", b =>
                {
                    b.Navigation("PeriodoAcademicoProgramas");

                    b.Navigation("Programas");
                });

            modelBuilder.Entity("DataAccess.Data.Entities.Programa", b =>
                {
                    b.Navigation("Competencias");

                    b.Navigation("PeriodoAcademicoProgramas");
                });
#pragma warning restore 612, 618
        }
    }
}
