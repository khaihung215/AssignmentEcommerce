using AssignmentEcommerce_Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentEcommerce_CustomerSite.ViewComponents
{
    public class ProductCardViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(ProductVm product)
        {         
            return await Task.FromResult(View("Default", product));
        }
    }
}
