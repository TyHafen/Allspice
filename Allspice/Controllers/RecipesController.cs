using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Allspice.Models;
using Allspice.Services;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;

namespace allspice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesService _recipesService;
        private readonly IngredientsService _ingredientsService;

        public RecipesController(RecipesService recipesService, IngredientsService ingredientsService)
        {
            _recipesService = recipesService;
            _ingredientsService = ingredientsService;
        }

        [HttpGet]
        public ActionResult<List<Recipe>> GetAll()
        {
            try
            {
                List<Recipe> recipes = _recipesService.GetAll();
                return Ok(recipes);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Recipe> GetRecipeById(int id)
        {
            try
            {
                Recipe recipe = _recipesService.GetRecipeById(id);
                return Ok(recipe);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }


        }


        [HttpGet("{id}/ingredients")]
        public ActionResult<List<Ingredient>> GetAllByRecipeId(int id)
        {
            try
            {
                List<Ingredient> ingredients = _ingredientsService.GetAll(id);
                return Ok(ingredients);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Recipe>> Create([FromBody] Recipe recipeData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                recipeData.CreatorId = userInfo.Id;
                Recipe recipe = _recipesService.Create(recipeData);
                recipe.Creator = userInfo;
                return Created($"api/recipes/{recipe.Id}", recipe);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<string>> Delete(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                _recipesService.Delete(id, userInfo);
                return Ok("deleted this recipe");
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}


