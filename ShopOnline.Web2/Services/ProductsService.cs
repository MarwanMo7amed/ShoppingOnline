using ShopOnline.Models.Dtos;
using ShopOnline.Web2.Services.Contracts;
using System.Net.Http.Json;

namespace ShopOnline.Web2.Services
{
    public class ProductsService:IProductService
    {
        private readonly HttpClient httpClient;

        public ProductsService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ProductDto> GetItem(int id)
        {
            try
            {
                var product = await this.httpClient.GetFromJsonAsync<ProductDto>($"api/Product/{id}");
                if (product == null) { 
                    return default (ProductDto);
                }
                return product;
            }
            catch {
                throw;
            }
        }

        public async Task<IEnumerable<ProductDto>> GetItems()
        {
            try
            {
                var products = await this.httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("api/Product");
                return products;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
