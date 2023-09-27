using ShopOnline.Api.Models;

namespace ShopOnline.Api.Repositories.Contract
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetItems();
        Task<Product> GetItem(int id);
        Task<IEnumerable<ProductCategory>> GetCategories();
        Task<ProductCategory> GetCategory(int categoryId);
    }
}
