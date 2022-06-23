﻿// <auto-generated />
using System;
using ConsultaAlumnosClase.API.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConsultaAlumnosClase.API.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("AlumnoMateria", b =>
                {
                    b.Property<int>("AlumnosId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MateriasEnCursoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AlumnosId", "MateriasEnCursoId");

                    b.HasIndex("MateriasEnCursoId");

                    b.ToTable("AlumnoMateria", (string)null);

                    b.HasData(
                        new
                        {
                            AlumnosId = 1,
                            MateriasEnCursoId = 1
                        },
                        new
                        {
                            AlumnosId = 1,
                            MateriasEnCursoId = 2
                        });
                });

            modelBuilder.Entity("ConsultaAlumnosClase.API.Entities.Consulta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlumnoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("EstadoConsulta")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("FechaFinalizacion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("FechaUltimaModificacion")
                        .HasColumnType("TEXT");

                    b.Property<int>("MateriaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProfesorAsignadoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AlumnoId");

                    b.HasIndex("MateriaId");

                    b.HasIndex("ProfesorAsignadoId");

                    b.ToTable("Consultas");
                });

            modelBuilder.Entity("ConsultaAlumnosClase.API.Entities.Materia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cuatrimestre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Materias");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cuatrimestre = "Tercer",
                            Nombre = "Programación 3"
                        },
                        new
                        {
                            Id = 2,
                            Cuatrimestre = "Tercer",
                            Nombre = "Programación 4"
                        });
                });

            modelBuilder.Entity("ConsultaAlumnosClase.API.Entities.Respuesta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ConsultaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CreadorId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Mensaje")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ConsultaId");

                    b.HasIndex("CreadorId");

                    b.ToTable("Respuestas");
                });

            modelBuilder.Entity("ConsultaAlumnosClase.API.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Usuario");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Usuario");
                });

            modelBuilder.Entity("MateriaProfesor", b =>
                {
                    b.Property<int>("MateriasAsignadasId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProfesoresId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MateriasAsignadasId", "ProfesoresId");

                    b.HasIndex("ProfesoresId");

                    b.ToTable("MateriaProfesor", (string)null);

                    b.HasData(
                        new
                        {
                            MateriasAsignadasId = 1,
                            ProfesoresId = 4
                        },
                        new
                        {
                            MateriasAsignadasId = 1,
                            ProfesoresId = 5
                        },
                        new
                        {
                            MateriasAsignadasId = 2,
                            ProfesoresId = 4
                        });
                });

            modelBuilder.Entity("ConsultaAlumnosClase.API.Entities.Alumno", b =>
                {
                    b.HasBaseType("ConsultaAlumnosClase.API.Entities.Usuario");

                    b.HasDiscriminator().HasValue("Alumno");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellido = "Bologna",
                            Email = "nbologna31@gmail.com",
                            Nombre = "Nicolas",
                            NombreUsuario = "nbologna_alumno",
                            Password = "123456"
                        },
                        new
                        {
                            Id = 2,
                            Apellido = "Perez",
                            Email = "Jperez@gmail.com",
                            Nombre = "Juan",
                            NombreUsuario = "jperez",
                            Password = "123456"
                        },
                        new
                        {
                            Id = 3,
                            Apellido = "Garcia",
                            Email = "pgarcia@gmail.com",
                            Nombre = "Pedro",
                            NombreUsuario = "pgarcia",
                            Password = "123456"
                        });
                });

            modelBuilder.Entity("ConsultaAlumnosClase.API.Entities.Profesor", b =>
                {
                    b.HasBaseType("ConsultaAlumnosClase.API.Entities.Usuario");

                    b.HasDiscriminator().HasValue("Profesor");

                    b.HasData(
                        new
                        {
                            Id = 4,
                            Apellido = "Bologna",
                            Email = "nbologna31@gmail.com",
                            Nombre = "Nicolas",
                            NombreUsuario = "nbologna_profesor",
                            Password = "123456"
                        },
                        new
                        {
                            Id = 5,
                            Apellido = "Paez",
                            Email = "ppaez@gmail.com",
                            Nombre = "Pablo",
                            NombreUsuario = "ppaez",
                            Password = "123456"
                        });
                });

            modelBuilder.Entity("AlumnoMateria", b =>
                {
                    b.HasOne("ConsultaAlumnosClase.API.Entities.Alumno", null)
                        .WithMany()
                        .HasForeignKey("AlumnosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsultaAlumnosClase.API.Entities.Materia", null)
                        .WithMany()
                        .HasForeignKey("MateriasEnCursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConsultaAlumnosClase.API.Entities.Consulta", b =>
                {
                    b.HasOne("ConsultaAlumnosClase.API.Entities.Alumno", "Alumno")
                        .WithMany("Consultas")
                        .HasForeignKey("AlumnoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsultaAlumnosClase.API.Entities.Materia", "Materia")
                        .WithMany()
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsultaAlumnosClase.API.Entities.Profesor", "ProfesorAsignado")
                        .WithMany("ConsultasAsignadas")
                        .HasForeignKey("ProfesorAsignadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alumno");

                    b.Navigation("Materia");

                    b.Navigation("ProfesorAsignado");
                });

            modelBuilder.Entity("ConsultaAlumnosClase.API.Entities.Respuesta", b =>
                {
                    b.HasOne("ConsultaAlumnosClase.API.Entities.Consulta", "Consulta")
                        .WithMany("Respuestas")
                        .HasForeignKey("ConsultaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsultaAlumnosClase.API.Entities.Usuario", "Creador")
                        .WithMany()
                        .HasForeignKey("CreadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consulta");

                    b.Navigation("Creador");
                });

            modelBuilder.Entity("MateriaProfesor", b =>
                {
                    b.HasOne("ConsultaAlumnosClase.API.Entities.Materia", null)
                        .WithMany()
                        .HasForeignKey("MateriasAsignadasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsultaAlumnosClase.API.Entities.Profesor", null)
                        .WithMany()
                        .HasForeignKey("ProfesoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConsultaAlumnosClase.API.Entities.Consulta", b =>
                {
                    b.Navigation("Respuestas");
                });

            modelBuilder.Entity("ConsultaAlumnosClase.API.Entities.Alumno", b =>
                {
                    b.Navigation("Consultas");
                });

            modelBuilder.Entity("ConsultaAlumnosClase.API.Entities.Profesor", b =>
                {
                    b.Navigation("ConsultasAsignadas");
                });
#pragma warning restore 612, 618
        }
    }
}