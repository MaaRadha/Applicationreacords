using System.ComponentModel.DataAnnotations;

namespace JoobTrackerData.Models
{
    public class JobListing
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string? CompanyName { get; set; }
        public string? CompanyMediaUrl { get; set; }
        [StringLength(150)]
        public string? CompanyPerson1name { get; set; }
        [StringLength(150)]
        public string? CompanyPerson2name { get; set; }
        [StringLength(150)]
        public string ContactPersonRole { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactPersonPhone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        [StringLength(150)]
        public string? Title { get; set; }
        public string? CompanyJobLink { get; set; }
        public string CompanyWebsiteLink { get; set; }
        [Required]
        [StringLength(150)]
        public string SubmissionDate { get; set; }
        public string? comments { get; set; }

        // Navigation property for the one-to-many relationship
        public List<Notes> Notes { get; set; } 

    }
}
