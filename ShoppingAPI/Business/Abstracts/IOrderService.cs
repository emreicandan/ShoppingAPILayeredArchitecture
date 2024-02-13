using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using ShoppingAPI.DTOs;
using ShoppingAPI.Entities;

namespace ShoppingAPI.Business.Abstracts;

public interface IOrderService
{
    IList<Order> GetAll(Expression<Func<Order, bool>>? predicate = null,
        Func<IQueryable<Order>, IIncludableQueryable<Order, object>>? include = null,
        Func<IQueryable<Order>, IOrderedQueryable<Order>>? orderBy = null);

    Order? Get(Expression<Func<Order, bool>> predicate,
        Func<IQueryable<Order>, IIncludableQueryable<Order, object>>? include = null);

    Order Add(AddOrderDto addOrderDto);

    Order Update(Order order);

    void DeleteById(Guid id);
}
