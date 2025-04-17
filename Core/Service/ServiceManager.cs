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
    public class ServiceManager : IServiceManager
    {
        public IProductService ProductService { get; }

        public ServiceManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            ProductService = new ProductService(unitOfWork, mapper);
        }
    }
}