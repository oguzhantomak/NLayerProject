using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerProject.Core.Models;

namespace NLayerProject.Repository.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Id alanı Primary Key olsun.
            builder.HasKey(x => x.Id);

            //Id alanı birer birer artsın(default değer seçildiği için).
            builder.Property(x => x.Id).UseIdentityColumn();

            //Name alanı zorunlu olsun ve uzunluğu en fazla 200 karakter olsun.
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);

            // Stock alanı zorunlu olsun.
            builder.Property(x => x.Stock).IsRequired();

            // Price alanı zorunlu ve decimal olacak. Toplam 18 karakter alabilecek ve virgülden sonra yalnızca 2 karakter alabilecek. 
            // Yani en fazla # ### ### ### ### ### , ## şeklinde olabilecek
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");

            // Bir Product nesnesinin bir Categorysi olabilir, bir Category'nin de birden fazla Product'ı olabilir, ve bunun Foreign Key'i Product içerisindeki CategoryId
            // 1-n relation
            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x=>x.CategoryId);
        }
    }
}
