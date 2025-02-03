using AutoMapper;
using JobTrackerData.DTO.JobListingDtos;
using JobTrackerData.Models;

namespace JobTrackerData.Profiles
{
    public class JobListingProfiles : Profile

    {
        public JobListingProfiles()
        {
            CreateMap<JobListing, JobListingReadDto>();
            CreateMap<JobListingUpdateDto, JobListing>();
            CreateMap<JobListingCreateDto, JobListing>();
            
        }
    }
}
