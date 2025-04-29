using GymManagementSystem_API.Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem_API.Entity
{
    public class Ahmet : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
    }
}
