using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using ShoppingAPI.Core;
using ShoppingAPI.Entities;

namespace ShoppingAPI.Business.Abstracts;
public interface IUserService
{

    IList<User> GetAll(Expression<Func<User, bool>>? predicate = null,
        Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null,
        Func<IQueryable<User>, IOrderedQueryable<User>>? orderBy = null);

    User? Get(Expression<Func<User, bool>> predicate,
        Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null);

    User Add(User user);

    User Update(User user);

    void DeleteById(Guid id);
}

