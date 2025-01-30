using System.Net.Http.Json;
using System.Text.Json;

namespace BlazorAppVisualStudio
{
    public class ProductService : IProductService
    {
        private readonly HttpClient client;

        private readonly JsonSerializerOptions options;
        //public ProductService(HttpClient httpclient, JsonSerializerOptions optionsJson) { 
        //    client = httpclient;
        //    options = optionsJson;
        //}

        public ProductService(HttpClient httpclient)
        {
            client = httpclient;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true }; ;
        }

        public async Task<List<Product>?> Get()
        {
            var response = await client.GetAsync("api/v1/products");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<List<Product>>(content, options);

        }
        public async Task<Product?> Get(int productId)
        {
            var response = await client.GetAsync($"v1/products/{productId}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode) throw new ApplicationException(content);
            return JsonSerializer.Deserialize<Product>(content, options);
        }

        public async Task Add(Product product)
        {
            var response = await client.PostAsync("api/v1/products", JsonContent.Create(product));
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }

        public async Task Delete(int productid)
        {
            var response = await client.DeleteAsync($"api/v1/products/{productid}");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }

        public async Task Update(Product product)
        {
            var response = await client.PutAsync($"api/v1/product/{product.Id}", JsonContent.Create(product));
            var content = await response.Content.ReadAsStringAsync();
            if(!response.IsSuccessStatusCode) { throw new ApplicationException(content); }
        }
    }

    public interface IProductService
    {
        Task<List<Product>?> Get();
        Task<Product?> Get(int productId);
        Task Add(Product product);
        Task Delete(int productid);
        Task Update(Product product);

    }
}
