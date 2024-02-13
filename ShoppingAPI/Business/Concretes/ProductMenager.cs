using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using ShoppingAPI.Business.Abstracts;
using ShoppingAPI.Business.Validations;
using ShoppingAPI.Entities;
using ShoppingAPI.Repositories.Abstract;

namespace ShoppingAPI.Business.Concretes;

public class ProductMenager : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ProductValidations _productValidations;

    public ProductMenager(IProductRepository productRepository, ProductValidations productValidations)
    {
        _productRepository = productRepository;
        _productValidations = productValidations;
    }

    public Product Add(Product product)
    {
        _productValidations.CheckPrice(product);
        return _productRepository.Add(product);
    }

    public void DeleteById(Guid id)
    {
        var product = _productRepository.Get(p => p.Id == id);
        _productValidations.IfExists(product);
        _productRepository.Delete(product);
    }

    public Product? Get(Expression<Func<Product, bool>> predicate, Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null)
    {
        return _productRepository.Get(predicate, include);
    }

    public IList<Product> GetAll(Expression<Func<Product, bool>>? predicate = null, Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null, Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null)
    {
        return _productRepository.GetAll(predicate, include, orderBy).ToList();
    }

    public Product Update(Product product)
    {
        _productValidations.CheckPrice(product);
        return _productRepository.Update(product);
    }
}

