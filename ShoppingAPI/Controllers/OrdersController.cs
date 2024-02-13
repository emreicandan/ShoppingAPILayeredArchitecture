using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingAPI.Business.Abstracts;
using ShoppingAPI.Business.Validations;
using ShoppingAPI.DTOs;
using ShoppingAPI.Entities;
using ShoppingAPI.Repositories.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_orderService.GetAll());
        }

        [HttpGet("GetAllWithDetail")]
        public IActionResult GetAllWithDetail()
        {
            return Ok(_orderService.GetAll(include: order => order.Include(o => o.User)
            .Include(o => o.OrderDetails).ThenInclude(od => od.Product).ThenInclude(p => p.Category)
            .Include(o => o.OrderDetails).ThenInclude(od => od.ProductTransaction)));
        }


        [HttpGet("GetById/{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_orderService.Get(order => order.Id == id));
        }


        [HttpPost("Add")]
        public IActionResult Add([FromBody]AddOrderDto addOrderDto)
        {
            return Ok(addOrderDto);
        }


        [HttpPut("Update")]
        public IActionResult Update([FromBody]Order order)
        {
            return Ok(_orderService.Update(order));
        }

        [HttpDelete("DeleteById/{id}")]
        public IActionResult Delete(Guid id)
        {
            _orderService.DeleteById(id);
            return Ok();
        }
    }
}

