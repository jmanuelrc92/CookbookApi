using CookBook_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBook_Api.Repositories
{
	public interface IRecipeCollection
	{
		Task InsertRecipe(Recipe recipe);
		Task UpdateRecipe(Recipe recipe);
		Task DeleteRecipe(string id);
		Task<List<Recipe>> GetAllRecipes();
		Task<Recipe> GetRecipeById(string id);
	}
}
