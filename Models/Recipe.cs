using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace CookBook_Api.Models
{
	public class Recipe
	{
		[BsonId]
		public ObjectId Id { get; set; }
		public string Name { get; set; }
		public List<string> Ingredients { get; set; }
	}
}
