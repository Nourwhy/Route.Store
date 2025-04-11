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
    public class BrandService(IUnitOfWork unitOfWork, IMapper mapper) : IBrandService
    {
        public async Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync()
        {
            var brands = await unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();
            if (brands is null) return null;
            var result = mapper.Map<IEnumerable<BrandResultDto>>(brands);
            return result;
        }
    }
}
