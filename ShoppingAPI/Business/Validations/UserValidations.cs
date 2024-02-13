using System;
using ShoppingAPI.Entities;

namespace ShoppingAPI.Business.Validations;

public class UserValidations
{

    public void CheckFirstName(User user)
    {
        if (user.FirstName.ToLower().Contains("allah"))
        {
            throw new Exception($"User name must not be {user.FirstName}");
        }
    }
    public void CheckLastName(User user)
    {
        if (user.FirstName.ToLower().Contains("allah"))
        {
            throw new Exception($"User name must not be {user.FirstName}");
        }
    }
    public void IfExists(User? user)
    {
        if (user == null) throw new Exception("User Not Found");
    }
}

