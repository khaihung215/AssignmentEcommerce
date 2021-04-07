﻿using AssignmentEcommerce_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentEcommerce_CustomerSite.Services
{
    public interface IProductApiClient
    {
        Task<IList<ProductVm>> GetProduct();
    }
}
