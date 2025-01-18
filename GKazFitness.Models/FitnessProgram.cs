using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GKazFitness.Models
{
    public class FitnessProgram
    {
        [Key]
        public int FitnessProgramId { get; set; }

        [Required]
        [StringLength(200)]
        public required string ProgramName { get; set; }

        [StringLength(3000)]
        public string? Description { get; set; }

        // If true, it's a template not tied to a particular user
        public bool IsTemplate { get; set; }

        // If this is a custom program for a client
        public int? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User? User { get; set; }
    }
}
