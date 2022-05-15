using CookBook_Api.Models.Settings;
using CookBook_Api.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Text.RegularExpressions;

namespace CookBook_Api.Services
{
	public class RecipeService : IRecipeService
	{
		private IMongoCollection<Recipe> _recipes;
		public RecipeService(IRecipeSettings settings)
		{
			var client = new MongoClient(settings.Server);
			var database = client.GetDatabase(settings.Database);

			_recipes = database.GetCollection<Recipe>(settings.Collection);
		}

		public async Task Add(Recipe recipe)
		{
			await _recipes.InsertOneAsync(recipe);
		}

		public async Task Delete(string id)
		{
			var filter = Builders<Recipe>.Filter.Eq(s => s.Id, new ObjectId(id));
			await _recipes.DeleteOneAsync(filter);
		}

		public async Task<List<Recipe>> Get()
		{
			return await _recipes.FindAsync(new BsonDocument()).Result.ToListAsync();
		}

		public async Task<Recipe> GetById(string id)
		{
			return await _recipes.FindAsync(
				new BsonDocument { { "_id", new ObjectId(id) } }
				).Result.FirstAsync();
		}

		public async Task<List<Recipe>> GetByIngredientMatch(IList<Ingredient> ingredientList)
		{
			return await _recipes.FindAsync(
				new BsonDocument("Ingredients", new BsonDocument(
					"$elemMatch", new BsonDocument(
						"Product", new Regex(ingredientList[0].Product)
						)
					))
				).Result.ToListAsync();
		}

		public async Task Update(Recipe recipe)
		{
			var filter = Builders<Recipe>.Filter.Eq(s => s.Id, recipe.Id);
			await _recipes.ReplaceOneAsync(filter, recipe);
		}
	}
}
