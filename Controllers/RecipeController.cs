using CookBook_Api.Models;
using CookBook_Api.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBook_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RecipeController : ControllerBase
	{
		private RecipeService _service;
		
		public RecipeController(RecipeService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return Ok(await _service.Get());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetRecipe(string id)
		{
			return Ok(await _service.GetById(id));
		}

		[HttpPost]
		public async Task<IActionResult> AddRecipe([FromBody] Recipe recipe)
		{
			if (recipe == null)
				return BadRequest();
			if (recipe.Name == string.Empty)
			{
				ModelState.AddModelError("Name", "Name is empty");
			}

			await _service.Add(recipe);
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
			await _service.Update(recipe);
			return Created("Created", true);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteRecipe(string id)
		{
			await _service.Delete(id);
			return NoContent();
		}

		[HttpPost]
		[Route("match")]
		public async Task<IActionResult> RecipeByIngredients([FromBody] IList<Ingredient> ingredientList)
		{
			if (ingredientList.Count == 0 || ingredientList.Count > 1)
			{
				return BadRequest();
			}
			return Ok(await _service.GetByIngredientMatch(ingredientList));
		}

	}
}
