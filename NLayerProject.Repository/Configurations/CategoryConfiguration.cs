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
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Id alanı Primary Key olsun.
            builder.HasKey(x => x.Id);

            //Id alanı birer birer artsın(default değer seçildiği için).
            builder.Property(x => x.Id).UseIdentityColumn();

            //Name alanı zorunlu olsun ve uzunluğu en fazla 50 karakter olsun.
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);


        }
    }
}
