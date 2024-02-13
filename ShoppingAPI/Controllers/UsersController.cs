using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.Business.Abstracts;
using ShoppingAPI.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService )
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }


        [HttpGet("GetById/{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_userService.Get(user => user.Id == id));
        }


        [HttpPost("Add")]
        public IActionResult Add([FromBody]User user)
        {
                return Ok(_userService.Add(user));
        }


        [HttpPut("Update")]
        public IActionResult Update([FromBody]User user)
        {
            return Ok(_userService.Update(user));
        }


        [HttpDelete("DeleteById/{id}")]
        public IActionResult Delete(Guid id)
        {
            _userService.DeleteById(id);
            return Ok();
        }
    }
}

