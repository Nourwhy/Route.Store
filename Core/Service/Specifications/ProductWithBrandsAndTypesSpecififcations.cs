using Domain.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace Service.Specifications
{
    public class ProductWithBrandsAndTypesSpecififcations : BaseSpecifications<Product,int>
    {
        public ProductWithBrandsAndTypesSpecififcations(int id): base(P=>P.Id==id)
        {
            ApplyIncludes();


        }

        public ProductWithBrandsAndTypesSpecififcations(ProductSpecificationPramaeters pramaeters)
                : base(
                    P =>
                    (string.IsNullOrEmpty(pramaeters.Search)|| P.Name.ToLower().Contains(pramaeters.Search.ToLower()))&&
                        (!pramaeters.BrandId.HasValue || P.BrandId == pramaeters.BrandId) &&
                        (!pramaeters.TypeId.HasValue || P.TypeId == pramaeters.TypeId) 
                )
            {
                ApplyIncludes();
            ApplySorting(pramaeters.Sort);
            ApplyPagination(pramaeters.PageIndex, pramaeters.PageSize);
              
            }
            private void ApplyIncludes()
        {

            AddInclude(P=>P.ProductBrand);
            AddInclude(P=>P.ProductType);
        }
        private void ApplySorting(string? sort)
        {
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort.ToLower())
                {
                    case "namedesc":
                        AddOrderByDescending(p => p.Name);
                        break;
                    case "priceasc":
                       AddOrderBy(p => p.Price);
                        break;
                    case "pricedesc":
                        AddOrderBy(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }
        }
    }
}
