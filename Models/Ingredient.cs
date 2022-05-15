using MongoDB.Bson.Serialization.Attributes;

namespace CookBook_Api.Models
{
	[BsonIgnoreExtraElements]
	public class Ingredient
	{
		public float Quantity { get; set; }
		public string Unit { get; set; }
		public string Product { get; set; }
		public string PreparationNotes { get; set; }
	}
}
