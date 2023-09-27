using System.Net.Http.Json;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contract;

namespace ShopOnline.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductDto>> GetItems()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("api/Product") ??
                       Array.Empty<ProductDto>();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
