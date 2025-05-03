using AutoMapper.Execution;
using GymManagementSystem_API.Entity;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem_API.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base (options)
        {  
        }

        public DbSet<Manager> Managers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Member> Members { get; set; }
     
    }
}
