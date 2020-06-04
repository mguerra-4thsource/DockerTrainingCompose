using System.ComponentModel.DataAnnotations;

namespace Docker_Training_Miguel_Guerra.Models
{
    public class Ticket
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Title { get; set; }

    }
}
