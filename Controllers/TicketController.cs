using Microsoft.AspNetCore.Mvc;
using Docker_Training_Miguel_Guerra.Models;
using System.Threading.Tasks;

namespace Docker_Training_Miguel_Guerra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly TicketContext db;

        public TicketController(TicketContext context)
        {
            db = context;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTicket(int id)
        {
            var tkt = await db.Tickets.FindAsync(id);
            if (tkt == default(Ticket))
            {
                return NotFound();
            }
            return Ok(tkt);
        }

        [HttpPost]
        public async Task<IActionResult> AddTicket([FromBody] Ticket tkt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await db.AddAsync(tkt);
            await db.SaveChangesAsync();
            return Ok(tkt.Id);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTicket(int id)

        {
            var tkt = await db.Tickets.FindAsync(id);
            if (tkt == default(Ticket))
            {
                return NotFound();
            }

            db.Tickets.Remove(tkt);
            db.SaveChanges();
            return Ok("Deleted");
        }

    }
}