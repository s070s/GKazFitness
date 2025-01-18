using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GKazFitness.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        // The trainer's UserId
        [Required]
        public required int TrainerId { get; set; }

        [ForeignKey(nameof(TrainerId))]
        [Required]
        [InverseProperty(nameof(User.TrainerAppointments))]
        public required virtual User Trainer { get; set; }

        // The client's UserId
        [Required]
        public required int ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        [Required]
        [InverseProperty(nameof(User.ClientAppointments))]
        public required virtual User Client { get; set; }

        // When the appointment will take place
        [Required]
        public required DateTime ScheduledDateTime { get; set; }

        // Any notes for preparation, instructions, etc.
        [StringLength(500)]
        public string? Notes { get; set; }
    }
}
