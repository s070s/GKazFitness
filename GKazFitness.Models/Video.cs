using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GKazFitness.Models
{
    public class Video
    {
        [Key]
        public int VideoId { get; set; }

        [Required]
        [StringLength(200)]
        public required string Title { get; set; }

        [Required]
        // Could store a YouTube link, social media link, etc.
        public required string Url { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        // You can store the platform type (YouTube, Instagram, etc.) if needed
        [StringLength(50)]
        public string? Platform { get; set; }

        // Optional link to the trainer profile if these videos are trainer-provided
        public int? TrainerProfileId { get; set; }

        [ForeignKey(nameof(TrainerProfileId))]
        public virtual TrainerProfile? TrainerProfile { get; set; }
    }
}
