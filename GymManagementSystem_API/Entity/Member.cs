using GymManagementSystem_API.Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem_API.Entity
{
    public class Member : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string NameSurname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; }
        public int UserTypeId { get; set; } 

    }
}
