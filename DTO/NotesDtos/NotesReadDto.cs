using System.ComponentModel.DataAnnotations;

namespace JobTrackerData.DTO.NotesDtos
{
    public class NotesReadDto
    {
        [Required]
        [StringLength(350)]
        public string CompanyName { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
