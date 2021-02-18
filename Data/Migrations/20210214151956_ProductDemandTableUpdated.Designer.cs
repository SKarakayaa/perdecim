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
    [Migration("20210214151956_ProductDemandTableUpdated")]
    partial class ProductDemandTableUpdated
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
                        },
                        new
                        {
                            Id = 4,
                            Name = "Matmazel"
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
                            CreatedAt = new DateTime(2021, 2, 14, 18, 19, 56, 97, DateTimeKind.Local).AddTicks(2474),
                            Name = "Perde"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2021, 2, 14, 18, 19, 56, 99, DateTimeKind.Local).AddTicks(5123),
                            Name = "Yatak Örtüsü"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2021, 2, 14, 18, 19, 56, 99, DateTimeKind.Local).AddTicks(5150),
                            Name = "Çeyiz"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2021, 2, 14, 18, 19, 56, 99, DateTimeKind.Local).AddTicks(5154),
                            Name = "Tül Perde",
                            ParentId = 1
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2021, 2, 14, 18, 19, 56, 99, DateTimeKind.Local).AddTicks(5158),
                            Name = "Normal Perde",
                            ParentId = 1
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2021, 2, 14, 18, 19, 56, 99, DateTimeKind.Local).AddTicks(5162),
                            Name = "Zebra Perde",
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

            modelBuilder.Entity("Entities.Concrete.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BrandId")
                        .HasColumnType("integer");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<int>("ColorId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("DiscountRate")
                        .HasColumnType("integer");

                    b.Property<bool>("InStock")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsNew")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Money")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ColorId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 4,
                            CategoryId = 6,
                            ColorId = 1,
                            CreatedAt = new DateTime(2021, 2, 14, 18, 19, 56, 100, DateTimeKind.Local).AddTicks(9830),
                            Description = "Zebra Stor Perde",
                            DiscountRate = 0,
                            InStock = true,
                            IsNew = true,
                            Money = 65.00m,
                            Name = "Yıldız Desen Baskılı Zebra Stor Perde"
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 4,
                            CategoryId = 6,
                            ColorId = 2,
                            CreatedAt = new DateTime(2021, 2, 14, 18, 19, 56, 101, DateTimeKind.Local).AddTicks(1252),
                            Description = "Zebra Stor Perde",
                            DiscountRate = 20,
                            InStock = true,
                            IsNew = false,
                            Money = 65.00m,
                            Name = "Jakarlı Zebra Stop Perde Su Yolu"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.ProductDemand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("DemandTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DemandTypeId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductDemands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DemandTypeId = 1,
                            ProductId = 1
                        },
                        new
                        {
                            Id = 2,
                            DemandTypeId = 1,
                            ProductId = 2
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

            modelBuilder.Entity("Entities.Concrete.Product", b =>
                {
                    b.HasOne("Entities.Concrete.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Concrete.ProductDemand", b =>
                {
                    b.HasOne("Entities.Concrete.DemandType", "DemandType")
                        .WithMany()
                        .HasForeignKey("DemandTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}