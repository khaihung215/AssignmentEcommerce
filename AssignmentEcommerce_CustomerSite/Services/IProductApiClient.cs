using AssignmentEcommerce_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentEcommerce_CustomerSite.Services
{
    public interface IProductApiClient
    {
        Task<IList<ProductVm>> GetProduct();

        Task<ProductVm> GetProductById(string id);

        Task<IList<ProductVm>> GetProductSameCategory(string id);

        Task<IList<ProductVm>> GetProductByCategory(string id);

        Task<IList<ReviewVm>> GetReviews(string id);

        Task<ReviewFormRequest> PostReview(ReviewFormRequest reviewFormRequest);
    }
}
