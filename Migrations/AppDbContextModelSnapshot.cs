﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using passagens_backend.Data;

#nullable disable

namespace passagens_backend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("passagens_backend.Models.Passagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CompanhiaAerea")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataChegada")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataPartida")
                        .HasColumnType("TEXT");

                    b.Property<string>("Destino")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Origem")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("Preco")
                        .HasColumnType("REAL");

                    b.Property<string>("StatusReservada")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Passagens");
                });

            modelBuilder.Entity("passagens_backend.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
