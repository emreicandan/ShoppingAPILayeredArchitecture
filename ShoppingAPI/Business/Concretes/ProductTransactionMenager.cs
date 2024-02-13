using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using ShoppingAPI.Business.Abstracts;
using ShoppingAPI.Business.Validations;
using ShoppingAPI.Entities;
using ShoppingAPI.Repositories.Abstract;

namespace ShoppingAPI.Business.Concretes;

public class ProductTransactionMenager : IProductTransactionService
{
    private readonly IProductTransactionRepository _productTransactionRepository;
    private readonly ProductTransactionValidations _productTransactionValidations;
	public ProductTransactionMenager(IProductTransactionRepository productTransactionRepository , ProductTransactionValidations productTransactionValidations)
	{
        _productTransactionValidations = productTransactionValidations;
        _productTransactionRepository = productTransactionRepository;
	}

    public ProductTransaction Add(ProductTransaction productTransaction)
    {
        return _productTransactionRepository.Add(productTransaction);
    }

    public void DeleteById(Guid id)
    {
        var productTransaction = _productTransactionRepository.Get(pt => pt.Id == id);
        _productTransactionValidations.IfExists(productTransaction);
        _productTransactionRepository.Delete(productTransaction);
    }

    public ProductTransaction? Get(Expression<Func<ProductTransaction, bool>> predicate, Func<IQueryable<ProductTransaction>, IIncludableQueryable<ProductTransaction, object>>? include = null)
    {
        return _productTransactionRepository.Get(predicate,include);
    }

    public IList<ProductTransaction> GetAll(Expression<Func<ProductTransaction, bool>>? predicate = null, Func<IQueryable<ProductTransaction>, IIncludableQueryable<ProductTransaction, object>>? include = null, Func<IQueryable<ProductTransaction>, IOrderedQueryable<ProductTransaction>>? orderBy = null)
    {
       return _productTransactionRepository.GetAll(predicate,include,orderBy).ToList();
    }

    public ProductTransaction Update(ProductTransaction productTransaction)
    {
       return _productTransactionRepository.Update(productTransaction);
    }
}

