using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace welcome_to_hell.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevilsController : ControllerBase
    {
        readonly _666Context _666Context;


        public DevilsController(_666Context _666Context)
        {
            this._666Context = _666Context;
        }

        [HttpPost("CreateDevil")]
        public async Task<ActionResult> CreateDevil(Devil devil)
        {
            _666Context.Devils.Add(devil);
            await _666Context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("EditDevil")]
        public async Task<ActionResult> EditDevil(Devil devil)
        {
            _666Context.Devils.Update(devil);
            await _666Context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("UpdateDevil")]
        public async Task<ActionResult> UpdateDevil(Devil devil)
        {
            _666Context.Devils.Update(devil);
            await _666Context.SaveChangesAsync();
            return Ok();
        }
    }
}
