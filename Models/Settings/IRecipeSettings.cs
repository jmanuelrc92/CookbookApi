namespace CookBook_Api.Models.Settings
{
	public interface IRecipeSettings
	{
		string Server { get; set; }
		string Database { get; set; }
		string Collection { get; set; }
	}
}
