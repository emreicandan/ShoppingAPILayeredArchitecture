using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingAPI.Business.Abstracts;
using ShoppingAPI.Entities;
using ShoppingAPI.Repositories.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_categoryService.GetAll());
        }

        [HttpGet("GetAllWithProduct")]
        public IActionResult GetAllWithProduct()
        {
            return Ok(_categoryService.GetAll(include: category => category.Include(c => c.Products)));
        }


        [HttpGet("GetById/{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_categoryService.Get(category => category.Id == id));
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody]Category category)
        {

            return Ok(_categoryService.Add(category));
        }


        [HttpPut("Update")]
        public IActionResult Update([FromBody]Category category)
        {
            return Ok(_categoryService.Update(category));
        }


        [HttpDelete("DeleteById/{id}")]
        public IActionResult Delete(Guid id)
        {
            _categoryService.DeleteById(id);
            return Ok();
        }
    }
}

