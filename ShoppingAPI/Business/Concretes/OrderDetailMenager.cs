using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using ShoppingAPI.Business.Abstracts;
using ShoppingAPI.Business.Validations;
using ShoppingAPI.Entities;
using ShoppingAPI.Repositories.Abstract;

namespace ShoppingAPI.Business.Concretes;


public class OrderDetailMenager : IOrderDetailService
{
    private readonly IOrderDetailRepository _orderDetailRepository;
    private readonly OrderDetailValidations _orderDetailValidations;

	public OrderDetailMenager(IOrderDetailRepository orderDetailRepository,OrderDetailValidations orderDetailValidations)
	{
        _orderDetailValidations = orderDetailValidations;
        _orderDetailRepository = orderDetailRepository;
	}

    public OrderDetail Add(OrderDetail orderDetail)
    {
      return  _orderDetailRepository.Add(orderDetail);
    }

    public void DeleteById(Guid id)
    {
        var orderDetail = _orderDetailRepository.Get(od => od.Id == id);
        _orderDetailValidations.IfExists(orderDetail);
        _orderDetailRepository.Delete(orderDetail);
    }

    public OrderDetail? Get(Expression<Func<OrderDetail, bool>> predicate, Func<IQueryable<OrderDetail>, IIncludableQueryable<OrderDetail, object>>? include = null)
    {
        return _orderDetailRepository.Get(predicate, include);
    }

    public IList<OrderDetail> GetAll(Expression<Func<OrderDetail, bool>>? predicate = null, Func<IQueryable<OrderDetail>, IIncludableQueryable<OrderDetail, object>>? include = null, Func<IQueryable<OrderDetail>, IOrderedQueryable<OrderDetail>>? orderBy = null)
    {
        return _orderDetailRepository.GetAll(predicate, include, orderBy).ToList();
    }

    public OrderDetail Update(OrderDetail orderDetail)
    {
        return _orderDetailRepository.Update(orderDetail);
    }
}

