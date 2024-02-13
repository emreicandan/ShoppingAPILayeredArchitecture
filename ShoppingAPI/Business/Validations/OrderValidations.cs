using System;
using ShoppingAPI.Business.Abstracts;
using ShoppingAPI.DTOs;
using ShoppingAPI.Entities;

namespace ShoppingAPI.Business.Validations;

public class OrderValidations
{
    private readonly IProductTransactionService _productTransactionService;

    public OrderValidations(IProductTransactionService productTransactionService)
    {
        _productTransactionService = productTransactionService;
    }

	public void IfExists(Order? order)
	{
		if (order == null)
            throw new Exception("Order not found");
	}

	public void CheckTransactionCount(AddOrderDto addOrderDto)
	{
        if (addOrderDto.ProductTransactions.Count() == 0)
        {
            throw new Exception("Product list connot be empty");
        };
    }

    public void CheckProductQuantity(AddOrderDto addOrderDto)
    {
        if (addOrderDto.ProductTransactions.Where(pt => pt.Quantity <= 0).Any())
        {
            throw new Exception("Product count must not be 0");
        }
    }

    public void CheckStock(AddOrderDto addOrderDto)
    {
       var checkCount = addOrderDto.ProductTransactions.Select(t =>
        _productTransactionService.GetAll(pt => pt.ProductId == t.ProductId).Sum(transaction => transaction.Quantity) - t.Quantity)
            .Where(q => q < 0).Any();
        if (checkCount)
        {
            throw new Exception("We are has not any product stock. Please check stock count");
        }
    }
}

