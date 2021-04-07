﻿using AssignmentEcommerce_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AssignmentEcommerce_CustomerSite.Services
{
    public class ProductApiClient : IProductApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IList<ProductVm>> GetProduct()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44311/api/product");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<ProductVm>>();
        }
    }
}
