using System.ComponentModel.DataAnnotations;

namespace JobTrackerData.DTO.NotesDtos
{
    public class NotesCreateDto
    {
       
        [Required]
        [StringLength(350)]
        public string CompanyName { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int JobListingId { get; set; }

    }
}
