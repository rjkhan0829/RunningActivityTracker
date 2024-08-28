using Microsoft.EntityFrameworkCore;
using RunningActivityTracker.Models;

namespace RunningActivityTracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<RunningActivity> RunningActivities { get; set; }
    }
}
