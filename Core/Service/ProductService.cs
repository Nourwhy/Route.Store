using AutoMapper;
using Domain.Contracts;
using Domain.Models;
using Service.Specifications;
using Services.Abstractions;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService(IUnitOfWork unitOfWork, IMapper mapper) : IProductService
    {



        public async Task<PaginationResponse<ProductResultDto>> GetAllProductsAsync(ProductSpecificationPramaeters pramaeters)

        {
            var spec = new ProductWithBrandsAndTypesSpecififcations(pramaeters);
            var products = await unitOfWork.GetRepository<Product, int>().GetAllAsync(spec);
            var count = await unitOfWork.GetRepository<Product, int>().CountAsync(spec);

            var specCount = new ProductWithCountSpecifications(pramaeters);
            var result = mapper.Map<IEnumerable<ProductResultDto>>(products);
            return new PaginationResponse<ProductResultDto>(pramaeters.PageIndex, pramaeters.PageSize,0,result);
        }



        public async Task<ProductResultDto?> GetProductByIdAsync(int id)
        {
            var spec = new ProductWithBrandsAndTypesSpecififcations(id);
            var product = await unitOfWork.GetRepository<Product, int>().GetAsync(spec);
            if (product is null) return null;
            var result = mapper.Map<ProductResultDto>(product);
            return result;
        }
        public async Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync()
        {
            Console.WriteLine("🔍 Getting brands...");

            var brands = await unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();

            if (brands is null)
            {
                Console.WriteLine("❌ brands is null!");
                return Enumerable.Empty<BrandResultDto>(); 
            }

            Console.WriteLine($"✅ Found {brands.Count()} brands.");

            var result = mapper.Map<IEnumerable<BrandResultDto>>(brands);
            return result;
        }

      
  
        public async Task<IEnumerable<TypeResultDto>> GetAllTypeAsync()
        {
            Console.WriteLine("🔍 Getting brands...");

            var types = await unitOfWork.GetRepository<ProductType, int>().GetAllAsync();

            if (types is null)
            {
                Console.WriteLine("❌ brands is null!");
                return Enumerable.Empty<TypeResultDto>(); 
            }

            Console.WriteLine($"✅ Found {types.Count()} brands.");

            var result = mapper.Map<IEnumerable<TypeResultDto>>(types);
            return result;
        }

        
    }

}