using Domain.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IProductService
    {
        //Get All Product
        Task<IEnumerable<ProductResultDto>> GetAllProductsAsync(ProductSpecificationPramaeters pramaeters);
        //GetProductById
        Task<ProductResultDto> GetProductByIdAsync(int id);
        //Get All Brands
        Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync();
        Task<IEnumerable<TypeResultDto>> GetAllTypeAsync();
    }
}
