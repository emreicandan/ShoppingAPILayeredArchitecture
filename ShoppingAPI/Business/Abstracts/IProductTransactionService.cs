﻿using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using ShoppingAPI.Entities;

namespace ShoppingAPI.Business.Abstracts
{
	public interface IProductTransactionService
	{
		IList<ProductTransaction> GetAll(Expression<Func<ProductTransaction, bool>>? predicate = null,
			Func<IQueryable<ProductTransaction>, IIncludableQueryable<ProductTransaction, object>>? include = null,
			Func<IQueryable<ProductTransaction>, IOrderedQueryable<ProductTransaction>>? orderBy = null);

		ProductTransaction? Get(Expression<Func<ProductTransaction, bool>> predicate,
			Func<IQueryable<ProductTransaction>, IIncludableQueryable<ProductTransaction, object>>? include = null);

		ProductTransaction Add(ProductTransaction productTransaction);

		ProductTransaction Update(ProductTransaction productTransaction);

		void DeleteById(Guid id);
	}
}

