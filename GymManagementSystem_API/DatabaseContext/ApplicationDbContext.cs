using AutoMapper.Execution;
using GymManagementSystem_API.Entity;
using GymManagementSystem_API.Entity.Base;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem_API.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {  
        }

        public DbSet<Entity.Manager> Managers { get; set; }
        public DbSet<Entity.Appointment> Appointments { get; set; }
        public DbSet<Entity.Member> Members { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
     
    }
}
