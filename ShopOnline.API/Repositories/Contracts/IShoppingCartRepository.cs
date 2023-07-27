using ShopOnline.API.Entities;
using ShopOnline.Models.Dtos;
namespace ShopOnline.API.Repositories.Contracts
{
    public interface IShoppingCartRepository
    {
        Task <CartItem> AddItem (CartItemToAddDto cartItemToAddDto);
        Task<CartItem> UpdateQty(int id, CartItemToAddDto cartItemToAddDto);
        Task<CartItem> DeleteItem(int id);
        Task<CartItem> GetItem (int id);
        Task<IEnumerable<CartItem>> GetCartItems(int userId);
    }
}
