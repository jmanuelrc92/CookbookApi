namespace CookBook_Api.Models.Settings
{
	public class RecipeSettings : IRecipeSettings
	{
		public string Server { get; set; }
		public string Database { get; set; }
		public string Collection { get; set; }
	}
}
