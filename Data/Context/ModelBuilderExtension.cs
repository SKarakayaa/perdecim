using System;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Perde", CreatedAt = DateTime.Now, ParentId = null },
                new Category { Id = 2, Name = "Yatak Örtüsü", CreatedAt = DateTime.Now, ParentId = null },
                new Category { Id = 3, Name = "Çeyiz", CreatedAt = DateTime.Now, ParentId = null },
                new Category { Id = 4, Name = "Tül Perde", CreatedAt = DateTime.Now, ParentId = 1 },
                new Category { Id = 5, Name = "Normal Perde", CreatedAt = DateTime.Now, ParentId = 1 },
                new Category { Id = 6, Name = "Zebra Perde", CreatedAt = DateTime.Now, ParentId = 1 }
            );

            modelBuilder.Entity<Color>().HasData(
                new Color { Id = 1, Name = "Ekru" },
                new Color { Id = 2, Name = "Pudra" },
                new Color { Id = 3, Name = "Vizon" },
                new Color { Id = 4, Name = "Kahve" }
            );

            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, Name = "Taç" },
                new Brand { Id = 2, Name = "English Home" },
                new Brand { Id = 3, Name = "Belenay" },
                new Brand { Id = 4, Name = "Matmazel" }
            );

            modelBuilder.Entity<DemandType>().HasData(
                new DemandType { Id = 1, Name = "Kasa Tipi" },
                new DemandType { Id = 2, Name = "Zincir Tipi" },
                new DemandType { Id = 3, Name = "Kasa Seçeneği" }
            );

            modelBuilder.Entity<Demand>().HasData(
                new Demand { Id = 1, DemandTypeId = 1, ImageName = "jumbo_kasa.jpeg", Name = "Jumbo Kasa" },
                new Demand { Id = 2, DemandTypeId = 1, ImageName = "metal_kasa.jpeg", Name = "Metal Kasa" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Yıldız Desen Baskılı Zebra Stor Perde", BrandId = 4, CategoryId = 6, ColorId = 1, Description = "Zebra Stor Perde", DiscountRate = 0, InStock = true, IsNew = true,IsPopular=true, Price = 65.00M },
                new Product { Id = 2, Name = "Jakarlı Zebra Stop Perde Su Yolu", BrandId = 4, CategoryId = 6, ColorId = 2, Description = "Zebra Stor Perde", DiscountRate = 20, InStock = true, IsNew = false,IsPopular=false, Price = 65.00M }
            );

            modelBuilder.Entity<ProductDemand>().HasData(
                new ProductDemand { Id = 1, DemandTypeId = 1, ProductId = 1 },
                new ProductDemand { Id = 2, DemandTypeId = 1, ProductId = 2 }
            );
        }
    }
}