﻿// <auto-generated />
using System;
using ChatApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChatApi.Migrations
{
    [DbContext(typeof(ChatContext))]
    [Migration("20200812171046_EsPregunta")]
    partial class EsPregunta
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChatApi.Models.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EsPregunta")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<long>("Leido")
                        .HasColumnType("bigint");

                    b.Property<int>("ReservaId")
                        .HasColumnType("int");

                    b.Property<long>("Respondido")
                        .HasColumnType("bigint");

                    b.Property<string>("Texto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReservaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Chat");
                });

            modelBuilder.Entity("ChatApi.Models.Mascotas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<bool>("Castrada")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idRaza")
                        .HasColumnType("int");

                    b.Property<int>("idUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Mascotas");
                });

            modelBuilder.Entity("ChatApi.Models.Reservas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<int>("Calificacion")
                        .HasColumnType("int");

                    b.Property<string>("ComentarioCalificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaAtencion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaGeneracion")
                        .HasColumnType("datetime2");

                    b.Property<int>("HoraAtencion")
                        .HasColumnType("int");

                    b.Property<int>("MascotaId")
                        .HasColumnType("int");

                    b.Property<string>("Motivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TramoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MascotaId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("ChatApi.Models.Usuarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Perfil")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ChatApi.Models.Chat", b =>
                {
                    b.HasOne("ChatApi.Models.Reservas", "Reserva")
                        .WithMany("chats")
                        .HasForeignKey("ReservaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChatApi.Models.Usuarios", "Usuario")
                        .WithMany("Chats")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ChatApi.Models.Reservas", b =>
                {
                    b.HasOne("ChatApi.Models.Mascotas", "Mascota")
                        .WithMany("Reservas")
                        .HasForeignKey("MascotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
