using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace welcome_to_hell.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacksController : ControllerBase
    {
        readonly _666Context _666Context;

        public RacksController(_666Context _666Context)
        {
            this._666Context = _666Context;
        }

        [HttpPost("CreateRack")]
        public async Task<ActionResult> CreateRack(Rack rack)
        {
            _666Context.Racks.Add(rack);
            await _666Context.SaveChangesAsync();
            return Ok("Куплен новый стеллаж");
        }

        [HttpPost("UpdateRack")]
        public async Task<ActionResult> UpdateRack(Rack rack)
        {
            
            _666Context.Racks.Update(rack);
            await _666Context.SaveChangesAsync();
            return Ok("У дьявола новый ранк");
        }

        [HttpPost("GetRacks")]
        public async Task<List<Rack>> GetRacks()
        {
            await Task.Delay(10);
            List<Rack> racks = new List<Rack>();
            racks = _666Context.Racks.ToList();
            return racks;
        }
    }
}
