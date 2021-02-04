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
                new Category { Id = 1, Name = "Perde", CreatedAt = DateTime.Now },
                new Category { Id = 2, Name = "Yatak Örtüsü", CreatedAt = DateTime.Now },
                new Category { Id = 3, Name = "Çeyiz", CreatedAt = DateTime.Now }
            );
        }
    }
}