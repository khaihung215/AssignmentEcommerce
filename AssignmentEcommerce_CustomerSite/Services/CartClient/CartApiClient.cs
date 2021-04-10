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
    public class CartApiClient : ICartApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartApiClient(IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IList<CartRespond>> GetCart()
        {
            var client = _httpClientFactory.CreateClient();
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.GetAsync("https://localhost:44311/api/carts/getcart");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<IList<CartRespond>>();
        }

        public async Task<CartCreateRequest> PostCart(CartCreateRequest cartCreateRequest)
        {
            var client = _httpClientFactory.CreateClient();
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(cartCreateRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:44311/api/carts/postcart", data);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<CartCreateRequest>();
        }

        public async Task<CartRespond> RemoveCart(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.DeleteAsync("https://localhost:44311/api/carts/removecart/" + id);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<CartRespond>();
        }
    }
}
