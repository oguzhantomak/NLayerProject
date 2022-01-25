using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NLayerProject.Core.DTOs.Product;
using NLayerProject.Core.Models;

namespace NLayerProject.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            // ReverMap demek Product'ı ProductDto'ya çevirirken, ProductDto'yu da Product'a çevirir.
            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<ProductUpdateDto, Product>();
        }
    }
}
