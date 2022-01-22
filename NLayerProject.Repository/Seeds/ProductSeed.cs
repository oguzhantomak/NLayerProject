using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerProject.Core.Models;

namespace NLayerProject.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    CategoryId = 1,
                    Price = 10,
                    Stock = 5,
                    Name = "Marul",
                    Barcode = "86901"
                },
                new Product
                {
                    Id = 2,
                    CategoryId = 2,
                    Price = 20,
                    Stock = 5,
                    Name = "Askılık",
                    Barcode = "86902"
                },
                new Product
                {
                    Id = 3,
                    CategoryId = 3,
                    Price = 15,
                    Stock = 5,
                    Name = "Yeişl Mercimek 2,5 kg",
                    Barcode = "86903"
                });
        }
    }
}
