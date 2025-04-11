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
    public class TypeService(IUnitOfWork unitOfWork, IMapper mapper) : ITypeService
    {
        public async Task<IEnumerable<TypeResultDto>> GetAllTypeAsync()
        {
            var types = await unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            if (types is null) return null;
            var result = mapper.Map<IEnumerable<TypeResultDto>>(types);
            return result;
            {

            }
        }
    }
}
