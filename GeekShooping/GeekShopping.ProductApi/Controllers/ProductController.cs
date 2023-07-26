using GeekShopping.ProductApi.Data.ValueObjects;
using GeekShopping.ProductApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductApi.Controllers
{
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentException(nameof(productRepository));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var productsVO = await _productRepository.FindAllAsync();
            if (!productsVO.Any())
            {
                return NotFound();
            }
            return Ok(productsVO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> FindByIdAsync(long id)
        {
            var productVO = await _productRepository.FindByIdAsync(id);
            if (productVO is null)
            {
                return NotFound();
            }
            return Ok(productVO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductVO productVO)
        {
            if (productVO is null)
                return BadRequest();

            return Created("Produto criado com sucesso", await _productRepository.CreateAsync(productVO));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductVO productVO)
        {
            if (productVO is null)
                return BadRequest();

            return Ok(await _productRepository.UpdateAsync(productVO));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] long id)
        {
            await _productRepository.DeleteAsync(id);

            return Ok("Produto removido com sucesso!");
        }
    }
}
