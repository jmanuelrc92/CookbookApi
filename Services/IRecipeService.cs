using CookBook_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBook_Api.Services
{
	public interface IRecipeService
	{
		Task Add(Recipe recipe);
		Task Update(Recipe recipe);
		Task Delete(string id);
		Task<List<Recipe>> Get();
		Task<Recipe> GetById(string id);
		Task<List<Recipe>> GetByIngredientMatch(IList<Ingredient> ingredientList);
	}
}
