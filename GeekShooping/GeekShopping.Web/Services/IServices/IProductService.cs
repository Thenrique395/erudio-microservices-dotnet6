using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> FindAllProductsAsync();
        Task<ProductModel> FindProductByIdAsync(long id);
        Task<ProductModel> CreateProductAsync(ProductModel productModel);
        Task<ProductModel> UpdateProductAsync(ProductModel productModel);
        Task<ProductModel> DeleteProductByIdAsync(long id);
    }
}
