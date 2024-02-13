using System;
using ShoppingAPI.Entities;

namespace ShoppingAPI.Business.Validations;

public class ProductTransactionValidations
{
    public void IfExists(ProductTransaction? productTransaction)
    {
        if (productTransaction == null)
            throw new Exception("Product Transaction not found");
    }
}

