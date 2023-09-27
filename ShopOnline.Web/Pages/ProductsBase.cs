using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contract;

namespace ShopOnline.Web.Pages
{
    public class ProductsBase : ComponentBase
    {
        [Inject]
        public IProductService ProductService { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Products = await ProductService.GetItems();
        }

        protected IEnumerable<IGrouping<int, ProductDto>> GetGroupedByCategory()
        {
            try
            {
                return Products
                    .GroupBy(d => d.CategoryId)
                    .OrderBy(e => e.Key)
                    .ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        protected string GetCategoryName(IGrouping<int, ProductDto> groupedProductDtos)
        {
            try
            {
                return groupedProductDtos
                    .FirstOrDefault(d => d.CategoryId.Equals(groupedProductDtos.Key))?.CategoryName ?? "No Name";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
