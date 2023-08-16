using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public const string basePath = "api/v1/product";

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ProductModel> CreateProductAsync(ProductModel productModel)
        {
            var response = await _httpClient.PostAsJson(basePath, productModel);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductModel>();
            else throw new Exception("something went wrong when calling API");
        }

        public async Task<ProductModel> DeleteProductByIdAsync(long id)
        {
            var response = await _httpClient.DeleteAsync($"basePath/{id}");
            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<IEnumerable<ProductModel>> FindAllProductsAsync()
        {
            var response = await _httpClient.GetAsync(basePath);
            return await response.ReadContentAs<List<ProductModel>>();
        }

        public async Task<ProductModel> FindProductByIdAsync(long id)
        {
            var response = await _httpClient.GetAsync($"basePath/{id}");
            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<ProductModel> UpdateProductAsync(ProductModel productModel)
        {
            var response = await _httpClient.PutAsJsonAsync(basePath, productModel);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductModel>();
            else throw new Exception("something went wrong when calling API");
        }
    }
}
