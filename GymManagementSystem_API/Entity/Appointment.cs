using GymManagementSystem_API.Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem_API.Entity
{
    public class Appointment : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; } = false;
        public int MemberId { get; set; }
        public int TrainerId { get; set; }

    }
}
