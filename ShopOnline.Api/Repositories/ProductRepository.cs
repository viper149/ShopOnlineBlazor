using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Data;
using ShopOnline.Api.Models;
using ShopOnline.Api.Repositories.Contract;

namespace ShopOnline.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopOnlineDbContext _shopOnlineDbContext;

        public ProductRepository(ShopOnlineDbContext shopOnlineDbContext)
        {
            _shopOnlineDbContext = shopOnlineDbContext;
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            try
            {
                return await _shopOnlineDbContext.Products.ToListAsync();
            }
            catch (Exception a)
            {
                Console.WriteLine(a);
                throw;
            }
        }

        public async Task<Product> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            try
            {
                return await _shopOnlineDbContext.ProductCategories.ToListAsync();
            }
            catch (Exception a)
            {
                Console.WriteLine(a);
                throw;
            }
        }

        public async Task<ProductCategory> GetCategory(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
