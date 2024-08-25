using CrudApplication.Core.Entities.Business;
using CrudApplication.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CrudApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(ILogger<ProductController> logger, IProductService productService) : ControllerBase
    {
        private readonly ILogger<ProductController> _logger = logger;
        private readonly IProductService _productService = productService;

        // GET: api/product
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetProducts();
            return Ok(products);
        }

        // GET api/product/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _productService.GetProduct(id);
            return Ok(data);
        }

        // GET: api/product/paginated
        [HttpGet("paginated")]
        public async Task<IActionResult> Get(int? pageNumber, int? pageSize)
        {
            int pageSizeValue = (pageSize ?? 4);
            int pageNumberValue = (pageNumber ?? 1);

            //Get peginated data
            var products = await _productService.GetPaginatedProducts(pageNumberValue, pageSizeValue);

            return Ok(products);
        }

        // POST api/product
        [HttpPost]
        public async Task<IActionResult> Create(ProductDto model)
        {
            var data = await _productService.Create(model);
            return Ok(data);
        }

        // PUT api/product/5
        [HttpPut]
        public async Task<IActionResult> Edit(ProductDto model)
        {
            await _productService.Update(model);
            return Ok();
        }


        // DELETE api/product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.Delete(id);
            return Ok();
        }
    }
}
