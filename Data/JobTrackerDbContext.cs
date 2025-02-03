using JoobTrackerData.Models;
using Microsoft.EntityFrameworkCore;

namespace JoobTrackerData.Data
{
    public class JobTrackerDbContext : DbContext
    {
        //models
        public DbSet<JobListing> JobListings { get; set; }
        public DbSet<Notes> Notes { get; set; }
        //constructor
        public JobTrackerDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    } 
    
}
