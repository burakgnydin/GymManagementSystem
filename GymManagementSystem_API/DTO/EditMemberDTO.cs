namespace GymManagementSystem_API.DTO
{
    public class EditMemberDTO
    {
        public int Id { get; set; }
        public string NameSurname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
