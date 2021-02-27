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
    [Migration("20210227090349_DemandPriceAdded")]
    partial class DemandPriceAdded
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
                            CreatedAt = new DateTime(2021, 2, 27, 12, 3, 48, 935, DateTimeKind.Local).AddTicks(8751),
                            Name = "Perde"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2021, 2, 27, 12, 3, 48, 939, DateTimeKind.Local).AddTicks(7463),
                            Name = "Yatak Örtüsü"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2021, 2, 27, 12, 3, 48, 939, DateTimeKind.Local).AddTicks(7540),
                            Name = "Çeyiz"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2021, 2, 27, 12, 3, 48, 939, DateTimeKind.Local).AddTicks(7547),
                            Name = "Tül Perde",
                            ParentId = 1
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2021, 2, 27, 12, 3, 48, 939, DateTimeKind.Local).AddTicks(7553),
                            Name = "Normal Perde",
                            ParentId = 1
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2021, 2, 27, 12, 3, 48, 939, DateTimeKind.Local).AddTicks(7560),
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

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("DemandTypeId");

                    b.ToTable("Demands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DemandTypeId = 1,
                            ImageName = "jumbo_kasa.jpeg",
                            Name = "Jumbo Kasa",
                            Price = 5.0m
                        },
                        new
                        {
                            Id = 2,
                            DemandTypeId = 1,
                            ImageName = "metal_kasa.jpeg",
                            Name = "Metal Kasa",
                            Price = 10.0m
                        },
                        new
                        {
                            Id = 3,
                            DemandTypeId = 2,
                            ImageName = "metal_zincir.jpeg",
                            Name = "Metal Zincir",
                            Price = 0m
                        },
                        new
                        {
                            Id = 4,
                            DemandTypeId = 2,
                            ImageName = "plasti_zincir.jpeg",
                            Name = "Plastik Zincir",
                            Price = 0m
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

                    b.Property<bool>("IsPopular")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

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
                            CreatedAt = new DateTime(2021, 2, 27, 12, 3, 48, 942, DateTimeKind.Local).AddTicks(3847),
                            Description = "Zebra Stor Perde",
                            DiscountRate = 0,
                            InStock = true,
                            IsNew = true,
                            IsPopular = true,
                            Name = "Yıldız Desen Baskılı Zebra Stor Perde",
                            Price = 65.00m
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 4,
                            CategoryId = 6,
                            ColorId = 2,
                            CreatedAt = new DateTime(2021, 2, 27, 12, 3, 48, 942, DateTimeKind.Local).AddTicks(6327),
                            Description = "Zebra Stor Perde",
                            DiscountRate = 20,
                            InStock = true,
                            IsNew = false,
                            IsPopular = false,
                            Name = "Jakarlı Zebra Stop Perde Su Yolu",
                            Price = 65.00m
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
                        },
                        new
                        {
                            Id = 3,
                            DemandTypeId = 2,
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
