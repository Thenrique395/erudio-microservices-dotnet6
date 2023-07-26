using GeekShopping.ProductApi.Data.ValueObjects;

namespace GeekShopping.ProductApi.Repository;
public interface IProductRepository
{
    Task<IEnumerable<ProductVO>> FindAllAsync();
    Task<ProductVO> FindByIdAsync(long id);
    Task<ProductVO> CreateAsync(ProductVO productVO);
    Task<ProductVO> UpdateAsync(ProductVO productVO);
    Task<ProductVO> DeleteAsync(long id);
}

