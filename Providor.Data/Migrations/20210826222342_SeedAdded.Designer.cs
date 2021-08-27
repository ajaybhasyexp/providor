﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Providor.Data;

namespace Providor.Data.Migrations
{
    [DbContext(typeof(ProvidorDBContext))]
    [Migration("20210826222342_SeedAdded")]
    partial class SeedAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Providor.Data.Models.Meter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MeterType")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfRegisters")
                        .HasColumnType("int");

                    b.Property<int>("OperatingMode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Meters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MeterType = 0,
                            NumberOfRegisters = 2,
                            OperatingMode = 0
                        },
                        new
                        {
                            Id = 2,
                            MeterType = 1,
                            NumberOfRegisters = 1,
                            OperatingMode = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
