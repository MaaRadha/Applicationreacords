using System.ComponentModel.DataAnnotations;

namespace JobTrackerData.DTO.JobListingDtos
{
    public class JobListingReadDto
    {
        
        [Required]
        [StringLength(450)]
        public string? CompanyName { get; set; }
        public string? CompanyMediaUrl { get; set; }
        [StringLength(450)]
        public string? CompanyPerson1name { get; set; }
        [StringLength(450)]
        public string? CompanyPerson2name { get; set; }
        [StringLength(450)]
        public string? ContactPersonRole { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactPersonPhone { get; set; }
        public string? City { get; set; }
        [StringLength(450)]
        public string? Title { get; set; }
        public string? CompanyJobLink { get; set; }
        [Required]
        [StringLength(350)]
        public string SubmissionDate { get; set; }
        public string? comments { get; set; }
    }
}
