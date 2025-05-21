namespace GymManagementSystem_API.DTO
{
    public class CreateAppointmentDto
    {
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public int MemberId { get; set; }
    }
}
