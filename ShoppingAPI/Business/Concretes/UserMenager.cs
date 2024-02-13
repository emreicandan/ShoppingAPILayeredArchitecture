using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using ShoppingAPI.Business.Abstracts;
using ShoppingAPI.Business.Validations;
using ShoppingAPI.Entities;
using ShoppingAPI.Repositories.Abstract;

namespace ShoppingAPI.Business.Concretes;

public class UserMenager : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly UserValidations _userValidations;

    public UserMenager(UserValidations userValidations , IUserRepository userRepository)
    {
        _userValidations = userValidations;
        _userRepository = userRepository;
    }

    public User Add(User user)
    {
        _userValidations.CheckFirstName(user);
        _userValidations.CheckLastName(user);
        return _userRepository.Add(user);
    }

    public User? Get(Expression<Func<User, bool>> predicate, Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null)
    {
        return _userRepository.Get(predicate, include);
    }

    public IList<User> GetAll(Expression<Func<User, bool>>? predicate = null, Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null, Func<IQueryable<User>, IOrderedQueryable<User>>? orderBy = null)
    {
        return _userRepository.GetAll(predicate, include, orderBy).ToList();
    }

    public User Update(User user)
    {
        _userValidations.CheckFirstName(user);
        _userValidations.CheckLastName(user);
        return _userRepository.Update(user);
    }

    void IUserService.DeleteById(Guid id)
    {
        var user = _userRepository.Get(u => u.Id == id);
        _userValidations.IfExists(user);
        _userRepository.Delete(user);
    }
}

