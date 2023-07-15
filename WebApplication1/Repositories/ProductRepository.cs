using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Reposotories.Contracts;
using WebApplication1.Data;
using WebApplication1.Entities;

namespace ShopOnline.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopOnlineDbContext shopOnlineDbContext;
        public ProductRepository(ShopOnlineDbContext shopOnlineDbContext)
        {
            this.shopOnlineDbContext = shopOnlineDbContext;
        }


        public async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            var categories=await this.shopOnlineDbContext.ProductCategories.ToListAsync();
            return categories;
        }

        public Task<ProductCategory> GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            var products = await this.shopOnlineDbContext.Products.ToListAsync();
            return products;
        }

        public Task<Product> GetItems(int id)
        {
            throw new NotImplementedException();
        }
    }
}
