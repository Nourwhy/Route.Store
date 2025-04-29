using Domain.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Specifications
{
    public class ProductWithCountSpecifications :BaseSpecifications<Product,int>
    {
        public ProductWithCountSpecifications(ProductSpecificationPramaeters pramaeters )
            : base(
                    P =>
                        (!pramaeters.BrandId.HasValue || P.BrandId == pramaeters.BrandId) &&
                        (!pramaeters.TypeId.HasValue || P.TypeId == pramaeters.TypeId)
                )
        {
            
        }
    }
}
