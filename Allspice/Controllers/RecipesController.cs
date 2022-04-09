using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Allspice.Models;
using Allspice.Services;

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
    }
}


