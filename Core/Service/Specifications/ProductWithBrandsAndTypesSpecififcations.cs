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
        public ProductWithBrandsAndTypesSpecififcations():base(null)
        {
            ApplyIncludes();

        }
        private void ApplyIncludes()
        {

            AddInclude(P=>P.ProductBrand);
            AddInclude(P=>P.ProductType);
        }
    }
}
