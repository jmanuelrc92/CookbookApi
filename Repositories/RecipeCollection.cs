using CookBook_Api.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBook_Api.Repositories
{
	public class RecipeCollection : IRecipeCollection
	{
		internal MongoDBRepository _repository = new MongoDBRepository();
		private IMongoCollection<Recipe> Collection;
		
		public RecipeCollection()
		{
			Collection = _repository.database.GetCollection<Recipe>("recipes");
		}
		public async Task DeleteRecipe(string id)
		{
			var filter = Builders<Recipe>.Filter.Eq(s => s.Id, new ObjectId(id));
			await Collection.DeleteOneAsync(filter);
		}

		public async Task<List<Recipe>> GetAllRecipes()
		{
			return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync<Recipe>();
		}

		public async Task<Recipe> GetRecipeById(string id)
		{
			return await Collection.FindAsync(
				new BsonDocument { { "_id", new ObjectId(id)} }
				).Result.FirstAsync();
		}

		public async Task InsertRecipe(Recipe recipe)
		{
			await Collection.InsertOneAsync(recipe);
		}

		public async Task UpdateRecipe(Recipe recipe)
		{
			var filter = Builders<Recipe>.Filter.Eq(s => s.Id, recipe.Id);
			await Collection.ReplaceOneAsync(filter, recipe);
		}
	}
}
