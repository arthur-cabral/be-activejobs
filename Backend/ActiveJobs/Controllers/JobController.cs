using Application.DTO.Job;
using Application.DTO.Pagination;
using Application.DTO.Response;
using Application.Interfaces;
using Domain.Pagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActiveJobs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<JobDTO>>> GetAll(
            [FromQuery] PaginationParametersDTO paginationParametersDTO)
        {
            var getJobs = await _jobService.GetAll(paginationParametersDTO);
            return Ok(getJobs);
        }

        [HttpGet("active")]
        public async Task<ActionResult<PagedList<JobDTO>>> GetAllActive(
            [FromQuery] PaginationParametersDTO paginationParametersDTO)
        {
            var getJobs = await _jobService.GetAllActive(paginationParametersDTO);
            return Ok(getJobs);
        }

        [HttpGet("{id}", Name = "GetById")]
        public async Task<ActionResult<JobDTO>> GetById(long id)
        {
            try
            {
                var getJob = await _jobService.GetById(id);
                if (getJob != null)
                {
                    return Ok(getJob);
                }
                return NotFound();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<MessageResponseDTO>> CreateJob(
            [FromBody] JobDTO jobDTO)
        {
            try
            {
                var response = await _jobService.CreateJob(jobDTO);
                return CreatedAtAction("GetById", new { message = response.Message }, response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<MessageResponseDTO>> UpdateJob(
            [FromBody] JobDTO jobDTO)
        {
            try
            {
                var response = await _jobService.UpdateJob(jobDTO);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageResponseDTO>> DeleteJob(long id)
        {
            var response = await _jobService.DeleteJob(id);
            if (response.Success)
            {
                return NoContent();
            }
            return NotFound(response.Message);
        }
    }
}
