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
    [Migration("20210314100828_CreatedAllAgain")]
    partial class CreatedAllAgain
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Entities.Concrete.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "e2bc170b-6776-488d-b932-da807331697f",
                            Name = "User"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "52e87537-00c8-40bc-91d1-177849be7985",
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

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
                            CreatedAt = new DateTime(2021, 3, 14, 13, 8, 27, 989, DateTimeKind.Local).AddTicks(44),
                            Name = "Perde"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2021, 3, 14, 13, 8, 27, 991, DateTimeKind.Local).AddTicks(2865),
                            Name = "Yatak Örtüsü"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2021, 3, 14, 13, 8, 27, 991, DateTimeKind.Local).AddTicks(2895),
                            Name = "Çeyiz"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2021, 3, 14, 13, 8, 27, 991, DateTimeKind.Local).AddTicks(2899),
                            Name = "Tül Perde",
                            ParentId = 1
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2021, 3, 14, 13, 8, 27, 991, DateTimeKind.Local).AddTicks(2904),
                            Name = "Normal Perde",
                            ParentId = 1
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2021, 3, 14, 13, 8, 27, 991, DateTimeKind.Local).AddTicks(2907),
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
                            CreatedAt = new DateTime(2021, 3, 14, 13, 8, 27, 992, DateTimeKind.Local).AddTicks(7434),
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
                            CreatedAt = new DateTime(2021, 3, 14, 13, 8, 27, 992, DateTimeKind.Local).AddTicks(9499),
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

            modelBuilder.Entity("Entities.Concrete.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ImageName")
                        .HasColumnType("text");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageName = "si.jpg",
                            ProductId = 2
                        },
                        new
                        {
                            Id = 2,
                            ImageName = "si1.jpg",
                            ProductId = 2
                        },
                        new
                        {
                            Id = 3,
                            ImageName = "si2.jpg",
                            ProductId = 2
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.ToTable("UserTokens");
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
                        .WithMany("Demands")
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
                        .WithMany("ProductDemands")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Concrete.ProductImage", b =>
                {
                    b.HasOne("Entities.Concrete.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}