using Application.DTO.Job;
using Application.DTO.Pagination;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper;

        public JobService(IJobRepository jobRepository, IMapper mapper)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
        }

        public async Task<PagedList<JobDTO>> GetAll(PaginationParametersDTO paginationParametersDTO)
        {
            var paginationParametersEntity = _mapper.Map<PaginationParameters>(paginationParametersDTO);
            var jobEntity = await _jobRepository.GetAll(paginationParametersEntity);
            return _mapper.Map<PagedList<JobDTO>>(jobEntity);
        }
    }
}
