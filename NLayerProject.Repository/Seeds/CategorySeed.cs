using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerProject.Core.Models;

namespace NLayerProject.Repository.Seeds
{
    internal class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Seed yaparken Id alanlarını kendimiz elle vermemiz gerekiyor
            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Taze"
                },
                new Category
                {
                    Id = 2,
                    Name = "Gıda Dışı"
                },
                new Category
                {
                    Id = 3,
                    Name = "Bakliyat"
                });
        }
    }
}
