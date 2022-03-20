using CookBook_Api.Models;
using CookBook_Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace CookBook_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RecipeController : ControllerBase
	{
		private IRecipeCollection recipeCollection = new RecipeCollection();

		[HttpGet]
		public async Task<IActionResult> GetAllRecipes()
		{
			return Ok(await recipeCollection.GetAllRecipes());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetRecipeDetails(string id)
		{
			return Ok(await recipeCollection.GetRecipeById(id));
		}

		[HttpPost]
		public async Task<IActionResult> CreateRecipe([FromBody] Recipe recipe)
		{
			if (recipe == null)
				return BadRequest();
			if (recipe.Name == string.Empty)
			{
				ModelState.AddModelError("Name", "Name is empty");
			}

			await recipeCollection.InsertRecipe(recipe);
			return Created("Created", true);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateRecipe([FromBody] Recipe recipe, string id)
		{
			if (recipe == null)
				return BadRequest();
			if (recipe.Name == string.Empty)
			{
				ModelState.AddModelError("Name", "Name is empty");
			}

			recipe.Id = new ObjectId(id);
			await recipeCollection.UpdateRecipe(recipe);
			return Created("Created", true);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteRecipe(string id)
		{
			await recipeCollection.DeleteRecipe(id);
			return NoContent();
		}
	}
}
