﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobTrackerData.Data;
using JobTrackerData.Models;
using JobTrackerData.DTO.JobListingDtos;
using AutoMapper;
using System.Net.Mime;

namespace JobTrackerData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes(MediaTypeNames.Application.Json)]

    public class JobListingsController : ControllerBase
    {
        private readonly JobTrackerDbContext _context;
        private readonly IMapper _mapper; // using AutoMapper;

        public JobListingsController(JobTrackerDbContext context, IMapper mapper) // Constructor injection
        {
            _context = context;
            _mapper = mapper; // using AutoMapper;
        }

        // GET: api/JobListings
        /// <summary>
        /// Get all of the JobListings
        /// </summary>
        /// <returns> A list of JobListings DTO </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<JobListingReadDto>>> GetJobListings()
        {
            var modelJobListings = await _context.JobListings.ToListAsync();
            return _mapper.Map<List<JobListingReadDto>>(modelJobListings); // using AutoMapper; 
        }

        // GET: api/JobListings/5
        /// <summary>
        /// Get a single JobListings by Id
        /// </summary>
        /// <param name="id">The ID of the JobListings</param>
        /// <returns> HTTP 200 response if successful</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<JobListingReadDto>> GetJobListing(int id)
        {
            var jobListing = await _context.JobListings.FindAsync(id);

            if (jobListing == null)
            {
                return NotFound();
            }

            return _mapper.Map<JobListingReadDto>(jobListing) ;
        }

        // PUT: api/JobListings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update the JobListings
        /// </summary>
        /// <param name="id">The ID of the JobListings to update.</param>
        /// <returns>An HTTP 204 response if successful.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutJobListing(int id, JobListingUpdateDto jobListingUpdateDto)
        {
            if (id != jobListingUpdateDto.Id)
            {
                return BadRequest();
            }

            var jobListing = _mapper.Map<JobListing>(jobListingUpdateDto); // using AutoMapper;

            _context.Entry(jobListing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobListingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/JobListings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add a new JobListings to the database
        /// </summary>
        /// <param name="jobListingCreateDto">A DTO containing the properties of the new JobListings</param>
        /// <returns>A DTO of the newly created</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<JobListingCreateDto>> PostJobListing(JobListingCreateDto jobListingCreateDto)
        {
            var jobListing =  _mapper.Map<JobListing>(jobListingCreateDto); // using AutoMapper;
            
            _context.JobListings.Add(jobListing);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobListing", new { id = jobListing.Id }, jobListingCreateDto);
        }

        // DELETE: api/JobListings/5
        /// <summary>
        /// Remove an JobListings from the database.
        /// </summary>
        /// <param name="id">The ID of the JobListings to delete.</param>
        /// <returns>An HTTP 204 response if successful.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteJobListing(int id)
        {
            var jobListing = await _context.JobListings.FindAsync(id);
            if (jobListing == null)
            {
                return NotFound();
            }

            _context.JobListings.Remove(jobListing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobListingExists(int id)
        {
            return _context.JobListings.Any(e => e.Id == id);
        }
    }
}
