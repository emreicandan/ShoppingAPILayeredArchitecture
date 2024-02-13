using System;
using ShoppingAPI.Entities;

namespace ShoppingAPI.Business.Validations
{
	public class CategoryValidations
	{
		public CategoryValidations()
		{
		}

		public void IfExists(Category? category)
		{
			if (category == null)
				throw new Exception("Category not found.");
		}
	}
}

