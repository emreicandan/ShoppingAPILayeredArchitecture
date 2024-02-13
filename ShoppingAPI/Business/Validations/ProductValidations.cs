using System;
using ShoppingAPI.Entities;

namespace ShoppingAPI.Business.Validations;

public class ProductValidations
{
    public void CheckPrice(Product? product)
    {
        if (product.Price <= 0)
        {
            throw new Exception("Product price cannot be 0 or less");
        }
    }
      public void IfExists(Product? product)
    {
        if (product == null)
            throw new Exception("Product not found");
    }
}

