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
    public class StepsController : ControllerBase
    {
        private readonly StepsService _stepsService;
        public StepsController(StepsService stepsService)
        {
            _stepsService = stepsService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Step>> Create([FromBody] Step stepData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                Step step = _stepsService.Create(stepData, userInfo);
                return Ok(step);
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
                _stepsService.Remove(id, userInfo);
                return Ok("Step Deleted");
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }




    }
}