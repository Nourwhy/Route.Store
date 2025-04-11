using AutoMapper;
using Domain.Contracts;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager(IUnitOfWork unitOfWork,IMapper mapper) : IServiceManager
    {
        public IProductService ProductService { get; } = new ProductService(unitOfWork, mapper);
        public IBrandService BrandService { get; } = new BrandService(unitOfWork, mapper);
        public ITypeService TypeService { get; } = new TypeService(unitOfWork, mapper);
    }
}
