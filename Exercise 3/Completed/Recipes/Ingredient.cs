namespace Recipes
{
	class Ingredient
	{
		public string Name        { get; set; }
		public double Amount      { get; set; }
		public string Units       { get; set; }
		public int    NumServings { get; set; } = 1;

		public override string ToString()
		{
			return Name + " " + (Amount * NumServings) + " " + Units;
		}
	}
}