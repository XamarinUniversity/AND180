using System.Collections.Generic;

namespace Recipes
{
	class Recipe
	{
		public string           Name        { get; set; }
		public List<Ingredient> Ingredients { get; set; }
		public bool             IsFavorite  { get; set; }

		public int NumServings
		{ 
			set
			{
				foreach (var i in Ingredients)
					i.NumServings = value;
			}
		}

		public override string ToString() { return (IsFavorite ? "*" : "") + Name; } // Use '*' as a simple way to indicate a 'favorite' recipe
	}
}