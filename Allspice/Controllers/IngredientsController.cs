using System.Collections.Generic;
using Allspice.Models;
using Allspice.Services;
using Microsoft.AspNetCore.Mvc;

namespace Allspice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IngredientsService _ingredientService;

        public IngredientsController(IngredientsService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet]
        public ActionResult<List<Ingredient>> GetAll()
        {
            try
            {
                List<Ingredient> ingredients = _ingredientService.GetAll();
                return Ok(ingredients);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }


        }





    }
}