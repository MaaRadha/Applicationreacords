using JobTrackerData.Models;
using Microsoft.EntityFrameworkCore;

namespace JobTrackerData.Data
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

        // Overrides - OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeding data
            List<JobListing> jobListings = new();
            List<Notes> notes = new();

            jobListings.Add(new JobListing
            {
                Id = 1,
                CompanyName = "Company1",
                CompanyMediaUrl = "https://www.company1.com",
                CompanyPerson1name = "Person1",
                CompanyPerson2name = "Person2",
                ContactPersonRole = "Role1",
                ContactEmail = "job@test@job.com",
                ContactPersonPhone = "John doe",
                Address = "1234 Main St",
                City = "Oslo",
                Title = "Frontend developer",
                CompanyJobLink = "https://www.company1.com/jobs",
                CompanyWebsiteLink = "https://www.company1.com",
                SubmissionDate = "2024-02-02",
                comments = "This is comment"
            });

            notes.Add(new Notes
            {
                Id = 1,
                CompanyName = "Company1",
                Content = "Content1",
                Date = DateTime.Now,
                JobListingId = 1
            });


            modelBuilder.Entity<JobListing>().HasData(jobListings);
            modelBuilder.Entity<Notes>().HasData(notes);
            //base.OnModelCreating(modelBuilder);
        }
    } 
    
}
