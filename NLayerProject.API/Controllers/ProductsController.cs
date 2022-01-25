using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.Core.DTOs;
using NLayerProject.Core.DTOs.Product;
using NLayerProject.Core.Models;
using NLayerProject.Core.Services;

namespace NLayerProject.API.Controllers
{
    //[Route("api/[controller]")] : Bu şu demek= GET api/products dediğimizde controller içerisinde tek bir GET metodlu, parametresiz action varsa direkt ona gidecek demek. Action'ın adını yazmaya gerek yok. api/products/5 dediğimde ise id parametresi alan GET metodlu action'a gidecek.
    [Route("api/[controller]")]
    [ApiController]
    //Bu Controller artık yeni yazdığımız base controller olan CustomBaseController'dan kalıtılacak.
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Product> _service;

        public ProductsController(IMapper mapper, IService<Product> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllAsync();
            var productDtos = _mapper.Map<List<ProductDto>>(products.ToList());

            //Global anlamda bir return kontrol oluşturmak için alttaki kodu commentledik ve CsutomBaseController yazdık.
            //return Ok(CustomResponseDto<List<ProductDto>>.Success(200, productDtos));

            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var mappedProductDto = _mapper.Map<ProductDto>(product);

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, mappedProductDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(product);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
