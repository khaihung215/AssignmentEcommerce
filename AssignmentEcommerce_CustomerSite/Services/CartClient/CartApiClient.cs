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
        private readonly HttpClient _client;

        public CartApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<IList<CartRespond>> GetCart()
        {
            var response = await _client.GetAsync("api/carts/getcart");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<IList<CartRespond>>();
        }

        public async Task<CartCreateRequest> PostCart(CartCreateRequest cartCreateRequest)
        {
            var json = JsonConvert.SerializeObject(cartCreateRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("api/carts/postcart", data);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<CartCreateRequest>();
        }

        public async Task<CartRespond> RemoveCart(string id)
        {
            var response = await _client.DeleteAsync("api/carts/removecart/" + id);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<CartRespond>();
        }

        public async Task<CartRespond> UpdateCart(CartUpdateRequest cartUpdateRequest)
        {
            var json = JsonConvert.SerializeObject(cartUpdateRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync("api/carts/updatecart", data);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<CartRespond>();
        }
    }
}
