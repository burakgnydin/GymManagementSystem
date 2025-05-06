namespace GymManagementSystem_API.DTO
{
    public class EditAppointmentDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; } = string.Empty;
        public int MemberId { get; set; }
    }
}