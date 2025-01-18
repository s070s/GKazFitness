using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GKazFitness.Models
{

    //Relationships
    //User ↔ TrainerProfile: One-to-one.A single User may have exactly one TrainerProfile(only if that user is the trainer).
    //User(Trainer) ↔ Appointment: One(trainer) to many(appointments).
    //User(Client) ↔ Appointment: One(client) to many(appointments).
    //User ↔ FitnessProgram: One user can have many custom fitness programs. (Templates don’t reference a user.)



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

        // Navigation: A user (if trainer) can have one trainer profile
        public virtual TrainerProfile? TrainerProfile { get; set; }

        // Navigation: A user can have many appointments (either as trainer or client)
        [InverseProperty("Trainer")]
        public virtual ICollection<Appointment>? TrainerAppointments { get; set; }

        [InverseProperty("Client")]
        public virtual ICollection<Appointment>? ClientAppointments { get; set; }

        // Navigation: A user can have multiple (custom) fitness programs
        public virtual ICollection<FitnessProgram>? FitnessPrograms { get; set; }
    }
}
