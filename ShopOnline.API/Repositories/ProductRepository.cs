﻿using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Reposotories.Contracts;
using ShopOnline.API.Data;
using ShopOnline.API.Entities;

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

        public async Task<ProductCategory> GetCategory(int id)
        {
            var category= await this.shopOnlineDbContext.ProductCategories.SingleOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            var products = await this.shopOnlineDbContext.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetItem(int id)
        {
            var product = await this.shopOnlineDbContext.Products.FindAsync(id);
            return product;
        }
    }
}
