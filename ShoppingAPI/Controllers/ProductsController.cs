using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingAPI.Business.Abstracts;
using ShoppingAPI.Entities;
using ShoppingAPI.Repositories.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_productService.GetAll());
        }

        [HttpGet("GetAllWithCategory")]
        public IActionResult GetAllWithCategory()
        {
            return Ok(_productService.GetAll(include: product => product.Include(p => p.Category)));
        }

        [HttpGet("GetBy{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_productService.Get(product => product.Id == id));
        }


        [HttpPost("Add")]
        public IActionResult Add([FromBody]Product product)
        {
            return Ok(_productService.Add(product));
        }


        [HttpPut("Update")]
        public IActionResult Update([FromBody] Product product)
        {
            return Ok(_productService.Update(product));
        }


        [HttpDelete("DeleteBy{id}")]
        public IActionResult Delete(Guid id)
        {
            _productService.DeleteById(id);
            return Ok();
        }
    }
}

