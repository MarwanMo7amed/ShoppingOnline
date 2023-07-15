using WebApplication1.Entities;

namespace ShopOnline.Api.Reposotories.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetItems();
        Task<IEnumerable<ProductCategory>> GetCategories();
        Task<Product> GetItems(int id);
        Task<ProductCategory> GetCategory(int id);
    }
}
