using ShopOnline.Models.Dtos;
namespace ShopOnline.Web2.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetItems();
        Task<ProductDto> GetItem(int id);
    }
}
