using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Models;

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
    }
}
