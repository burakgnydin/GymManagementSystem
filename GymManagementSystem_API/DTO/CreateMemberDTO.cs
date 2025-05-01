namespace GymManagementSystem_API.DTO
{
    public class CreateMemberDTO
    {
        public string NameSurname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
