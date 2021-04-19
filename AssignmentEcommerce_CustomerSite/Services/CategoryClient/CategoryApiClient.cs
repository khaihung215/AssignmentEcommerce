using AssignmentEcommerce_Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AssignmentEcommerce_CustomerSite.Services
{
    public class CategoryApiClient : ICategoryApiClient
    {
        private readonly HttpClient _client;

        public CategoryApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<IList<CategoryVm>> GetCategory()
        {
            var response = await _client.GetAsync("api/categories");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<CategoryVm>>();
        }
    }
}
