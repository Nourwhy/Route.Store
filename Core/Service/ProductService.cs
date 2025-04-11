using AutoMapper;
using Domain.Contracts;
using Domain.Models;

using Services.Abstractions;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService(IUnitOfWork unitOfWork,IMapper mapper) : IProductService
    {

       

        public async Task<IEnumerable<ProductResultDto>> GetAllProductsAsync()
        {
            var products = await unitOfWork.GetRepository<Product, int>().GetAllAsync();

            var result = mapper.Map<IEnumerable<ProductResultDto>>(products);
            return result;
        }

        

        public async Task<ProductResultDto?> GetProductByIdAsync(int id)
        {
            var product = await unitOfWork.GetRepository<Product, int>().GetAsync(id);
            if (product is null) return null;
            var result=mapper.Map<ProductResultDto>(product);
            return result;
        }
    }
}
