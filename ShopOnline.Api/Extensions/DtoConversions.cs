using ShopOnline.Api.Models;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<ProductDto> ConvertToDto(this IEnumerable<Product> products, IEnumerable<ProductCategory> productCategories)
        {
            try
            {
                return products
                    .Join(productCategories, p => p.CategoryId, c => c.Id,
                        (p, c) => new ProductDto
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Description = p.Description,
                            ImageURL = p.ImageURL,
                            Price = p.Price,
                            Qty = p.Qty,
                            CategoryId = p.CategoryId,
                            CategoryName = c.Name
                        }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
