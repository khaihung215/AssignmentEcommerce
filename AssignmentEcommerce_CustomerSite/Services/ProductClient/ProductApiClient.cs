using AssignmentEcommerce_Shared;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentEcommerce_CustomerSite.Services
{
    public class ProductApiClient : IProductApiClient
    {
        private readonly HttpClient _client;

        public ProductApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<IList<ProductVm>> GetProduct()
        {
            var response = await _client.GetAsync("api/product");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<ProductVm>>();
        }

        public async Task<ProductVm> GetProductById(string id)
        {
            var response = await _client.GetAsync("api/product/getproductbyid/" + id);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ProductVm>();
        }

        public async Task<IList<ProductVm>> GetProductSameCategory(string id)
        {
            var response = await _client.GetAsync("api/product/getproductsamecategory/" + id);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<ProductVm>>();
        }

        public async Task<IList<ProductVm>> GetProductByCategory(string id)
        {
            var response = await _client.GetAsync("api/product/getproductbycategory/" + id);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<ProductVm>>();
        }

        public async Task<IList<ReviewVm>> GetReviews(string id)
        {
            var response = await _client.GetAsync("api/reviews/getreviews/" + id);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<ReviewVm>>();
        }

        public async Task<ReviewFormRequest> PostReview(ReviewFormRequest reviewFormRequest)
        {
            var json = JsonConvert.SerializeObject(reviewFormRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("api/reviews/postreview", data);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ReviewFormRequest>();
        }
    }
}
