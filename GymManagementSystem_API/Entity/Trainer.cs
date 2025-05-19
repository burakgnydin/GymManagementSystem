using GymManagementSystem_API.Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem_API.Entity
{
    public class Trainer : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string NameSurname { get; set; } = string.Empty;
        public bool IsTraining { get; set; } = false;
        public int AppointmentId { get; set; } 
    }
}
