using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using ShoppingAPI.Entities;

namespace ShoppingAPI.Business.Abstracts;

public interface ICategoryService
{
    IList<Category> GetAll(Expression<Func<Category, bool>>? predicate = null,
        Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null,
        Func<IQueryable<Category>, IOrderedQueryable<Category>>? orderBy = null);

    Category? Get(Expression<Func<Category, bool>> predicate,
        Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null);

    Category Add(Category category);

    Category Update(Category category);

    void DeleteById(Guid id);
}
