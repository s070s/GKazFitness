using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GKazFitness.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public required string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public required string LastName { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [StringLength(200)]
        // In production, store hashed passwords/identity tokens instead.
        public required string PasswordHash { get; set; }

        [Phone]
        [StringLength(25)]
        public string? PhoneNumber { get; set; }

        // Distinguish the single trainer from clients
        public bool IsTrainer { get; set; }
    }
}
