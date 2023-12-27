using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(c => c.ProductID);
            builder.Property(c => c.ProductName).IsRequired();
            builder.Property(c => c.unitPrice).IsRequired();

            builder.HasData(
                new Product() { ProductID = 1, ProductName = "Bilgisayar", ProductDescription = "son model işlemciye sahip", ProductRanking = 0, unitPrice = 1000, ImageUrl = "null", Stock = 10, CategoryID = 1 },
                new Product() { ProductID = 2, ProductName = "Telefon", ProductDescription = "son model işlemciye sahip", ProductRanking = 0, unitPrice = 1000, ImageUrl = "null", Stock = 10, CategoryID = 1 ,ShowCase = true },
                new Product() { ProductID = 3, ProductName = "kitap", ProductDescription = "son model işlemciye sahip", ProductRanking = 0, unitPrice = 1000, ImageUrl = "null", Stock = 10, CategoryID = 2 },
                new Product() { ProductID = 4, ProductName = "kitap", ProductDescription = "son model işlemciye sahip", ProductRanking = 0, unitPrice = 1000, ImageUrl = "null", Stock = 10, CategoryID = 2 ,ShowCase = true },
                new Product() { ProductID = 5, ProductName = "telefon", ProductDescription = "son model işlemciye sahip", ProductRanking = 0, unitPrice = 1000, ImageUrl = "null", Stock = 10, CategoryID = 3 ,ShowCase = true }


            );
        }
    }
}