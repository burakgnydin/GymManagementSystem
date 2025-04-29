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

        public DbSet<Entity.Member> Members { get; set; }
        public DbSet<Entity.Appointment> Appointments { get; set; }
        public DbSet<Entity.UserType> UserTypes { get; set; }   
    }
}
