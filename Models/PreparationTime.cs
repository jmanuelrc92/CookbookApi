using MongoDB.Bson.Serialization.Attributes;

namespace CookBook_Api.Models
{
	public class PreparationTime
	{
		public int Time { get; set; }
		public string Unit { get; set; }
	[BsonIgnoreIfNull]
		public int TimeInSeconds { get; set; }
	}
}
