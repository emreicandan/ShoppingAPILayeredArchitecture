using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using ShoppingAPI.Business.Abstracts;
using ShoppingAPI.Business.Validations;
using ShoppingAPI.DTOs;
using ShoppingAPI.Entities;
using ShoppingAPI.Repositories.Abstract;

namespace ShoppingAPI.Business.Concretes;

public class OrderMenager : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductTransactionService _productTransactionService;
    private readonly IOrderDetailService _orderDetailService;
    private readonly OrderValidations _orderValidations;

    public OrderMenager(IOrderRepository orderRepository , OrderValidations orderValidations,
       IOrderDetailService orderDetailService , IProductTransactionService productTransactionService )
    {
        _orderRepository = orderRepository;
        _orderValidations = orderValidations;
        _productTransactionService = productTransactionService;
        _orderDetailService = orderDetailService;
    }

    public Order Add(AddOrderDto addOrderDto)
    {
        _orderValidations.CheckProductQuantity(addOrderDto);
        _orderValidations.CheckTransactionCount(addOrderDto);
        _orderValidations.CheckStock(addOrderDto);
        var addedOrder = _orderRepository.Add(new()
        {
            UserId = addOrderDto.UserId,
            CreatedDate = DateTime.UtcNow,
        });
        addOrderDto.ProductTransactions.ToList().ForEach(productTransaction =>
        {
            productTransaction.Quantity = productTransaction.Quantity > 0 ? -1 * productTransaction.Quantity : productTransaction.Quantity;
            var addedProductTransaction = _productTransactionService.Add(productTransaction);
            _orderDetailService.Add(new()
            {
                ProductId = productTransaction.ProductId,
                OrderId = addedOrder.Id,
                ProductTransactionId = addedProductTransaction.Id

            });
        });
        return addedOrder;
    }

    public void DeleteById(Guid id)
    {
        var order = _orderRepository.Get(o => o.Id == id);
        _orderValidations.IfExists(order);
        _orderRepository.Delete(order);
    }

    public Order? Get(Expression<Func<Order, bool>> predicate, Func<IQueryable<Order>, IIncludableQueryable<Order, object>>? include = null)
    {
        return _orderRepository.Get(predicate, include);
    }

    public IList<Order> GetAll(Expression<Func<Order, bool>>? predicate = null, Func<IQueryable<Order>, IIncludableQueryable<Order, object>>? include = null, Func<IQueryable<Order>, IOrderedQueryable<Order>>? orderBy = null)
    {
        return _orderRepository.GetAll(predicate, include, orderBy).ToList();
    }

    public Order Update(Order order)
    {
        return _orderRepository.Update(order);
    }
}

