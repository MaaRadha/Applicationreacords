using System.ComponentModel.DataAnnotations;

namespace JobTrackerData.DTO.NotesDtos
{
    public class NotesUpdateDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(350)]
        public string CompanyName { get; set; }
        [Required]
        public string Content { get; set; }
        public int JobListingId { get; set; }

    }
}
