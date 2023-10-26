using Application.DTO.Job;
using Application.DTO.Pagination;
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
    }
}
