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
