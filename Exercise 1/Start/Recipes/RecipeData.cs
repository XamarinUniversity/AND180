using System.Collections.Generic;

namespace Recipes
{
	class RecipeData
	{
		public static List<Recipe> Recipes { get; private set; }

		static RecipeData()
		{
			Recipes = new List<Recipe>();

			Recipes.Add(new Recipe()
			{
				Name = "Shake",
				Ingredients = new List<Ingredient>()
				{
					new Ingredient() { Name = "Banana", Amount = 4, Units = "oz" },
					new Ingredient() { Name = "Yogurt", Amount = 3, Units = "oz" },
					new Ingredient() { Name = "Juice", Amount = 6, Units = "oz" },
				}
			});

			Recipes.Add(new Recipe()
			{
				Name = "Pasta",
				Ingredients = new List<Ingredient>()
				{
					new Ingredient() { Name = "Noodles", Amount = 6, Units = "oz" },
					new Ingredient() { Name = "Salt", Amount = 1, Units = "pinch" },
					new Ingredient() { Name = "Pepper", Amount = 1, Units = "pinch" },
					new Ingredient() { Name = "Butter", Amount = 1, Units = "oz" },
				}
			});

			Recipes.Add(new Recipe()
			{
				Name = "Sandwich",
				Ingredients = new List<Ingredient>()
				{
					new Ingredient() { Name = "Bread", Amount = 2, Units = "slices" },
					new Ingredient() { Name = "Cheese", Amount = 3, Units = "oz" },
					new Ingredient() { Name = "Tomato", Amount = 1, Units = "oz" },
					new Ingredient() { Name = "Lettuce", Amount = 0.25, Units = "oz" },
				}
			});
		}
	}
}