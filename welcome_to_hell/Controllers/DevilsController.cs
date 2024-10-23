using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

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
            return Ok("Дьявол прибыл в ад");
        }

        [HttpPost("EditDevil")]
        public async Task<ActionResult> EditDevil(Devil devil)
        {
            _666Context.Devils.Update(devil);
            await _666Context.SaveChangesAsync();
            return Ok("У дьявола новое погоняло");
        }

        [HttpPost("UpdateDevil")]
        public async Task<ActionResult> UpdateDevil(Devil devil)
        {
            _666Context.Devils.Update(devil);
            await _666Context.SaveChangesAsync();
            return Ok("У дьявола новый ранк");
        }

        [HttpPost("DeleteDevil")]
        public async Task<ActionResult> DeleteDevil(Devil devil)
        {
            _666Context.Devils.Remove(devil);
            await _666Context.SaveChangesAsync();
            return Ok("Дьявола изгнали");
        }

        [HttpPost("GetDevils")]
        public async Task<List<Devil>> GetDevils()
        {
            await Task.Delay(10);
            List<Devil> devils = new List<Devil>();
            devils = _666Context.Devils.Include(s=>s.Racks).ToList();
            return devils;
        }
    }
}
