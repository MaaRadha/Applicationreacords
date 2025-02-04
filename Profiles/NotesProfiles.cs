using AutoMapper;
using JobTrackerData.DTO.NotesDtos;
using JobTrackerData.Models;

namespace JobTrackerData.Profiles
{
    public class NotesProfiles : Profile
    {
        public NotesProfiles()
        {
            CreateMap<Notes, NotesReadDto>();
            CreateMap<NotesCreateDto, Notes>();
            CreateMap<NotesUpdateDto, Notes>();
        }
    }
    
}
