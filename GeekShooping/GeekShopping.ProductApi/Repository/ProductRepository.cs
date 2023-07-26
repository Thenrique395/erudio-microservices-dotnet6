using AutoMapper;
using GeekShopping.ProductApi.Data.ValueObjects;
using GeekShopping.ProductApi.Model;
using GeekShopping.ProductApi.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyContext _myContext;
        private readonly IMapper _mapper;

        public ProductRepository(MyContext myContext, IMapper mapper)
        {
            _myContext = myContext;
            _mapper = mapper;
        }
        public async Task<ProductVO> CreateAsync(ProductVO productVO)
        {
            var product = _myContext.Products.AddAsync(_mapper.Map<Product>(productVO));
            await _myContext.SaveChangesAsync();
            return await _mapper.Map<Task<ProductVO>>(product);
        }

        public async Task<ProductVO> DeleteAsync(long id)
        {
            try
            {
                var product = await _myContext.Products.FindAsync(id);
                if (product is not null)
                {
                    _myContext.Products.Remove(product);
                    return await _mapper.Map<Task<ProductVO>>(product);
                }
                throw new Exception("Error ao deletar");
            }
            catch (Exception)
            {
                throw new Exception("Error ao deletar");
            }
        }

        public async Task<IEnumerable<ProductVO>> FindAllAsync()
        {
            var products = await _myContext.Products.ToListAsync();
            return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<ProductVO> FindByIdAsync(long id)
        {
            var product = await _myContext.Products.FindAsync(id);
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO> UpdateAsync(ProductVO productVO)
        {
            var product = await _myContext.Products.AddAsync(_mapper.Map<Product>(productVO));
            await _myContext.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }
    }
}
