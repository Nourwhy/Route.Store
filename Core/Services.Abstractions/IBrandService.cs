﻿using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync();
    }
}
