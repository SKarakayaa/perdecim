﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.Migrations
{
    [DbContext(typeof(MatmazelContext))]
    [Migration("20210214150127_DemandsTablesAdded")]
    partial class DemandsTablesAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Entities.Concrete.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Taç"
                        },
                        new
                        {
                            Id = 2,
                            Name = "English Home"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Belenay"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2021, 2, 14, 18, 1, 27, 58, DateTimeKind.Local).AddTicks(980),
                            Name = "Perde"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2021, 2, 14, 18, 1, 27, 60, DateTimeKind.Local).AddTicks(7085),
                            Name = "Yatak Örtüsü"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2021, 2, 14, 18, 1, 27, 60, DateTimeKind.Local).AddTicks(7118),
                            Name = "Çeyiz"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2021, 2, 14, 18, 1, 27, 60, DateTimeKind.Local).AddTicks(7121),
                            Name = "Tül Perde",
                            ParentId = 1
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2021, 2, 14, 18, 1, 27, 60, DateTimeKind.Local).AddTicks(7127),
                            Name = "Normal Perde",
                            ParentId = 1
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Colors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ekru"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Pudra"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Vizon"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Kahve"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Demand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("DemandTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("ImageName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DemandTypeId");

                    b.ToTable("Demands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DemandTypeId = 1,
                            ImageName = "jumbo_kasa.jpeg",
                            Name = "Jumbo Kasa"
                        },
                        new
                        {
                            Id = 2,
                            DemandTypeId = 1,
                            ImageName = "metal_kasa.jpeg",
                            Name = "Metal Kasa"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.DemandType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DemandTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Kasa Tipi"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Zincir Tipi"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Kasa Seçeneği"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Category", b =>
                {
                    b.HasOne("Entities.Concrete.Category", "ParentCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Entities.Concrete.Demand", b =>
                {
                    b.HasOne("Entities.Concrete.DemandType", "DemandType")
                        .WithMany()
                        .HasForeignKey("DemandTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
