using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Models;
using NLayerProject.Repository.Configurations;

namespace NLayerProject.Repository
{
    public class AppDbContext : DbContext
    {
        //Veritabanı yolunu startup(.net 6'da kalktı program.cs var) üzerinden alacağımız için DbContextOptions alan bir constructor oluşturuyoruz.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        // Model oluşurken çalışacak metodumuz.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // FluentValidation - Entitylerin özelliklerini bu şekilde(aşağıdaki gibi) belirleyebiliriz ama böyle yaparsak DbContext kirlenecek/dolacak. Bunun yerine ayrı bir classta configurationları belirliyoruz.

            //modelBuilder.Entity<Category>().HasKey(x => x.Id);

            // Her ClassLibrary bir assemblydir. Aşağıdaki metot ise bu assembly içerisindeki tüm Configuration dosyalarını okuyor. Nasıl okuyor ? Bizim tüm Configuration dosyalarımız "IEntityTypeConfiguration" bunu implement ettiği için reflaction yaparak bu interface'e sahip olan tüm classları buluyor.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Eğer tek bir Configuration'ı çalıştırmak isteseydik aşağıdaki gibi çalıştırabilirdik.
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
