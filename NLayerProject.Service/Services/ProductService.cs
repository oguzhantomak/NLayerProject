using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NLayerProject.Core.DTOs;
using NLayerProject.Core.DTOs.Product;
using NLayerProject.Core.Models;
using NLayerProject.Core.Repositories;
using NLayerProject.Core.Services;
using NLayerProject.Core.UnitOfWorks;

namespace NLayerProject.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IRepository<Product> repository, IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory()
        {
            
            var products = await _productRepository.GetProductsWithCategory();

            var productsDto = _mapper.Map<List<ProductWithCategoryDto>>(products);

            return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, productsDto);
        }
    }
}
