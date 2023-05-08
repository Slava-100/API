using Microsoft.EntityFrameworkCore;
using TechnoTest.DAL.Models;

namespace TechnoTest.DAL
{
    public class Context : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserGroupEntity> UserGroups { get; set; }
        public DbSet<UserStateEntity> UserStates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql("Host=localhost;Port=5432;Database=TechnoTest;Username=postgres;Password=Svyatoslav2005vecrfnvecrfn");
        }
    }
}
