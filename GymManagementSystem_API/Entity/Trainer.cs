using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem_API.Entity
{
    public class Trainer
    {
        [Key]
        public int Id { get; set; }
        public string NameSurname { get; set; } = string.Empty;
        public bool IsTraining { get; set; }
        public int AppointmentId { get; set; }
    }
}
