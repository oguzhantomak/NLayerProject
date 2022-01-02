using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayerProject.Core.Models;

namespace NLayerProject.Core.Services
{
    /// <summary>
    /// Sadece Product'a özgü işlemlerin yer alacağı interface. İç metotlarımızı tanımlayacağımız interface.
    /// </summary>
    public interface IProductService : IService<Product>
    {
        ///// <summary>
        ///// Metot product nesnesi alıyor, barkod kontrolü işlemini yapıyor ve bool dönüyor.
        ///// </summary>
        ///// <param name="product">Kontrol edilecek barkoda ait ürün parametresi.</param>
        ///// <returns></returns>
        //bool ControlInnerBarcode(Product product);

        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}
