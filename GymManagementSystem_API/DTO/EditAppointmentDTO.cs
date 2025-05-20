namespace GymManagementSystem_API.DTO
{
    public class EditAppointmentDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; } 
        public int MemberId { get; set; }
    }
}