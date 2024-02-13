﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.Business.Abstracts;
using ShoppingAPI.Entities;
using ShoppingAPI.Repositories.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductTransactionsController : Controller
    {
        private readonly IProductTransactionService _productTransactionService;

        public ProductTransactionsController(IProductTransactionService productTransactionService)
        {
            _productTransactionService = productTransactionService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_productTransactionService.GetAll());
        }


        [HttpGet("GetById/{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_productTransactionService.Get(productTransaction => productTransaction.Id == id));
        }


        [HttpPost("Add")]
        public IActionResult Add([FromBody]ProductTransaction productTransaction)
        {
            return Ok(_productTransactionService.Add(productTransaction));
        }

        // PUT api/values/5
        [HttpPut("Update")]
        public IActionResult Update([FromBody] ProductTransaction productTransaction)
        {
            return Ok(_productTransactionService.Update(productTransaction));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _productTransactionService.DeleteById(id);
            return Ok();
        }
    }
}

