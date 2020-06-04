using Microsoft.EntityFrameworkCore;

namespace Docker_Training_Miguel_Guerra.Models
{
    public class TicketContext:DbContext
    {

        public DbSet<Ticket> Tickets { get; set; }

        public TicketContext(DbContextOptions options) : base(options) { }
    }
}
