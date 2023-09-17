using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeAPI.Entity;
using PracticeAPI.Model;
using PracticeAPI.Repository;

namespace PracticeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repo;

        public ProductController(IMapper mapper, IProductRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var list = await _repo.GetAll();
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllProduct(int id)
        {
            var list = await _repo.GetById(id);
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductModel product)
        {
            var productEntity = _mapper.Map<ProductEntity>(product);
            await _repo.AddProduct(productEntity);
            return Ok(productEntity.ProductId);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(int id, ProductEntity product)
        {
            if (id == product.ProductId)
            {
                await _repo.UpdateProduct(id, product);
                return Ok(product);
            }
            return BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _repo.GetById(id);
            if(product == null)
            {
                return NotFound();
            }
            await _repo.DeleteProduct(id);
            return Ok(id);
        }
    }
}
