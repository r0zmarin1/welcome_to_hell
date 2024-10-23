using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace welcome_to_hell.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisposalController : ControllerBase
    {
        readonly _666Context _666Context;

        public DisposalController(_666Context _666Context)
        {
            this._666Context = _666Context;
        }

        [HttpPost("DeleteRacks")]
        public async Task<ActionResult> DeleteRacks(RackBl rack)
        {
            var original = _666Context.Racks.Find(rack.Id);
            Disposal disposal = new Disposal
            {
                Title = original.Title,
                Year = original.YearBuy
            };
            _666Context.Disposals.Add(disposal);
            _666Context.Racks.Remove(original);
            await _666Context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("GetDisposals")]
        public async Task<List<Disposal>> GetDisposals()
        {
            await Task.Delay(10);
            List<Disposal> disposals = new List<Disposal>();
            disposals = _666Context.Disposals.ToList();
            return disposals;
        }
    }
}
