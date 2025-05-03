namespace GymManagementSystem_API.DTO
{
    public class CreateManagerDTO
    {
        public string NameSurname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
