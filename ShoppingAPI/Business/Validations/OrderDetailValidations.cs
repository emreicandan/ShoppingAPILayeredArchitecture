using System;
using ShoppingAPI.Entities;

namespace ShoppingAPI.Business.Validations;

public class OrderDetailValidations
{

    public void IfExists(OrderDetail? orderDetail)
    {
        if (orderDetail == null) throw new Exception("Order detail not found");
    }

}

