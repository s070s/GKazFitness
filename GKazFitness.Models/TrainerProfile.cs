using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GKazFitness.Models
{
    //Relationships
    //TrainerProfile ↔ Video: Optionally, many videos can point to one trainer profile if they’re trainer-specific.

    public class TrainerProfile
    {
        [Key]
        public int TrainerProfileId { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public required virtual User User { get; set; }

        [StringLength(1000)]
        public string? Bio { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string? ContactEmail { get; set; }

        [Phone]
        [StringLength(25)]
        public string? ContactPhone { get; set; }
    }
}
