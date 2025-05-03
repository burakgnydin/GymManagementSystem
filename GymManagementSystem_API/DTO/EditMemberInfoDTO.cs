namespace GymManagementSystem_API.DTO
{
    public class EditMemberInfoDTO
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public float Height { get; set; }
        public float AmountOfWater { get; set; } = 0;
    }
}
