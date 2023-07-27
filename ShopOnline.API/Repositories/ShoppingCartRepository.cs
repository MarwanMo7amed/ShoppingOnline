using Microsoft.EntityFrameworkCore;
using ShopOnline.API.Repositories.Contracts;
using ShopOnline.Models.Dtos;
using System.Runtime.InteropServices;
using ShopOnline.API.Data;
using ShopOnline.API.Entities;

namespace ShopOnline.API.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ShopOnlineDbContext shopOnlineDbContext;
        public ShoppingCartRepository(ShopOnlineDbContext shopOnlineDbContext)
        {
            this.shopOnlineDbContext = shopOnlineDbContext;
        }
        private async Task<bool> CartItemExists(int cartId, int productId)
        {
            return await this.shopOnlineDbContext.CartsItem.
                AnyAsync(c=>c.CartId==cartId && c.ProductId==productId);
        }
        public async Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto)
        {
            if (await CartItemExists(cartItemToAddDto.CartId, cartItemToAddDto.ProductId)==false)
            {
                var item = await (from product in shopOnlineDbContext.Products
                                  where product.Id == cartItemToAddDto.ProductId
                                  select new CartItem
                                  {
                                      CartId = cartItemToAddDto.CartId,
                                      ProductId = product.Id,
                                      Qty = cartItemToAddDto.Qty
                                  }).SingleOrDefaultAsync();
                if (item != null)
                {
                    var result = await this.shopOnlineDbContext.CartsItem.AddAsync(item);
                    await this.shopOnlineDbContext.SaveChangesAsync();
                    return result.Entity;
                }
            }
            return null;
        }

        public Task<CartItem> DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CartItem>> GetCartItems(int userId)
        {
            var item= await (from cart in shopOnlineDbContext.Carts
                             join cartItem in this.shopOnlineDbContext.CartsItem
                             on cart.Id equals cartItem.CartId
                             where cart.UserId == userId
                             select new CartItem
                             {
                                 Id= cartItem.Id,
                                 ProductId= cartItem.ProductId,
                                 Qty= cartItem.Qty,
                                 CartId= cartItem.CartId
                             }).ToListAsync();
            if(item != null)
                return item;
            return null;
        }

        public async Task<CartItem> GetItem(int id)
        {
            return await (from cart in shopOnlineDbContext.Carts
                          join cartItem in this.shopOnlineDbContext.CartsItem
                          on cart.Id equals cartItem.CartId
                          where cart.Id == id
                          select new CartItem
                          {
                              Id=cartItem.Id, 
                              ProductId= cartItem.ProductId,
                              Qty= cartItem.Qty,
                              CartId=cartItem.CartId
                          }).SingleOrDefaultAsync();
        }

        public Task<CartItem> UpdateQty(int id, CartItemToAddDto cartItemToAddDto)
        {
            throw new NotImplementedException();
        }
    }
}
