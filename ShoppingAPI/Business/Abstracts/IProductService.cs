using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using ShoppingAPI.Entities;

namespace ShoppingAPI.Business.Abstracts;

public interface IProductService
{
    IList<Product> GetAll(Expression<Func<Product, bool>>? predicate = null,
        Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null,
        Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null);

    Product? Get(Expression<Func<Product, bool>> predicate,
        Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null);

    Product Add(Product product);

    Product Update(Product product);

    void DeleteById(Guid id);
}
