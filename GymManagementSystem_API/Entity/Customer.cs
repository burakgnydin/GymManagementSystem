using GymManagementSystem_API.Entity.Base;
using Microsoft.AspNetCore.Routing.Constraints;
using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem_API.Entity
{
    public class Customer : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string NameSurname { get; set; } = string.Empty;
        public int Age { get; set; }
        public int Weight { get; set; }
        public float Height { get; set; }
        public float AmountOfWater { get; set; }
        public int MemberId { get; set; }
    }
}
