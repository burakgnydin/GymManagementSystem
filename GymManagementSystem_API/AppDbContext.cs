namespace GymManagementSystem_API
{
    using Microsoft.EntityFrameworkCore;

    namespace GymManagementSystem_API
    {
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        }
    }

}
