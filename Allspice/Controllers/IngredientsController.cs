using System;
using System.Threading.Tasks;
using Allspice.Models;
using Allspice.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
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


        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Ingredient>> Create([FromBody] Ingredient ingredientData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                Ingredient ingredient = _ingredientService.Create(ingredientData, userInfo.Id);
                return Ok(ingredient);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }

        }
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Ingredient>> Edit([FromBody] Ingredient updates, int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                updates.Id = id;
                Ingredient updated = _ingredientService.Edit(updates, userInfo);
                return Ok(updates);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }


        }



        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<string>> Remove(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                _ingredientService.Remove(id, userInfo);
                return Ok("deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }





    }
}