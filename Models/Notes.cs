﻿using System.ComponentModel.DataAnnotations;

namespace JobTrackerData.Models
{
    public class Notes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(350)]
        public string CompanyName { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime Date { get; set; }
        // Foreign key for the relationship
        public int JobListingId { get; set; }
        // Navigation property for the relationship
        //public JobListing JobListing { get; set; }
    }
}
