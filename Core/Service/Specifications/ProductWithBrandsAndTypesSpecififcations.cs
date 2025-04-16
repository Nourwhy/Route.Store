using Domain.Models;
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

        public ProductWithBrandsAndTypesSpecififcations(int? brandId, int? typeId, string? sort)
                : base(
                    P =>
                        (!brandId.HasValue || P.BrandId == brandId) &&
                        (!typeId.HasValue || P.TypeId == typeId) 
                )
            {
                ApplyIncludes();
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
