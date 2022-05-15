using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace CookBook_Api.Models
{
	[BsonIgnoreExtraElements]
	public class Recipe
	{
		[BsonId]
		public ObjectId Id { get; set; }
		public string Name { get; set; }
		public PreparationTime PreparationTime { get; set; }
		public int Portions { get; set; }
		public IList<Ingredient> Ingredients { get; set; }
		public IList<PreparationStep> PreparationSteps { get; set; }
	}
}
