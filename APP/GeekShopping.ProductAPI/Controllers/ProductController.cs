using GeekShopping.Product.API.Data.Repository;
using GeekShopping.Product.API.Data.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Product.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> GetAllAsync()
        {
            var products = await _repository.FindAll();
            if (!products.Any()) return NotFound();
            
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> GetByIdAsync(int id)
        {
            var product = await _repository.FindById(id);
            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductVO>> CreateProductAsync([FromBody] ProductVO vo)
        {
            if (vo == null) return BadRequest();

            var product = await _repository.Create(vo);

            return Ok(product);
        }

        [HttpPut]
        public async Task<ActionResult<ProductVO>> UpdateProductAsync([FromBody] ProductVO vo)
        {
            if (vo == null) return BadRequest();
            
            var product = await _repository.FindById(vo.Id);
            if (product == null) return NotFound();
            
            var updatedProduct = await _repository.Update(vo);
            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductAsync(int id)
        {
            var product = await _repository.FindById(id);
            if (product == null) return NotFound();

            if (await _repository.Delete(id)) return Ok();
            else return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
