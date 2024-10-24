using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult> CreateRack(RackBl rack)
        {
            try
            {
                var rackNew = new Rack { CurrentCount = rack.CurrentCount, IdDevil =  rack.IdDevil, Title = rack.Title, UseCount = rack.UseCount, YearBuy = rack.YearBuy };
                _666Context.Racks.Add(rackNew);
                await _666Context.SaveChangesAsync();
                return Ok("Куплен новый стеллаж");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        [HttpPost("UpdateRack")]
        public async Task<ActionResult> UpdateRack(RackBl rack)
        {
            var rackNew = new Rack {Id = rack.Id, CurrentCount = rack.CurrentCount, IdDevil = rack.IdDevil, Title = rack.Title, UseCount = rack.UseCount, YearBuy = rack.YearBuy };
            _666Context.Racks.Update(rackNew);
            await _666Context.SaveChangesAsync();
            return Ok("У дьявола новый ранк");
        }

        [HttpPost("GetRacks")]
        public async Task<List<Rack>> GetRacks()
        {
            await Task.Delay(10);
            List<Rack> racks = new List<Rack>();
            racks = _666Context.Racks.Include(s=>s.IdDevilNavigation).ToList();
            return racks;
        }
    }
}
