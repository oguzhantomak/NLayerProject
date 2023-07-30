using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Models;
using NLayerProject.Core.Repositories;

namespace NLayerProject.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
            //Eager Loading. Product datasını çekerken categorylerinde alınmasını istedik.
            return await _appDbContext.Products
                .Include(c => c.Category)
                .ToListAsync();
        }
    }
}
