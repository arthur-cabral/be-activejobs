using Application.DTO.Job;
using Application.DTO.Pagination;
using Application.DTO.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
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

        public async Task<PagedList<JobDTO>> GetAllActive(PaginationParametersDTO paginationParametersDTO)
        {
            var paginationParametersEntity = _mapper.Map<PaginationParameters>(paginationParametersDTO);
            var jobEntity = await _jobRepository.GetAllActive(paginationParametersEntity);
            return _mapper.Map<PagedList<JobDTO>>(jobEntity);
        }

        public async Task<JobDTO> GetById(long id)
        {
            try
            {
                if (await _jobRepository.ExistsById(id))
                {
                    var jobEntity = await _jobRepository.GetById(id);
                    return _mapper.Map<JobDTO>(jobEntity);
                }
                return null;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MessageResponseDTO> CreateJob(JobDTO jobDTO)
        {
            try
            {
                jobDTO.Active = true;
                var jobEntity = _mapper.Map<Job>(jobDTO);
                await _jobRepository.CreateJob(jobEntity);

                return new MessageResponseDTO(true, "Vaga criada com sucesso");
            } catch (Exception ex)
            {
                return new MessageResponseDTO(false, ex.Message);
            }
        }

        public async Task<MessageResponseDTO> UpdateJob(JobDTO jobDTO)
        {
            bool existsJob = await _jobRepository.ExistsById(jobDTO.Id);
            if (!existsJob)
            {
                return new MessageResponseDTO(false, "Vaga não encontrada");
            }
            try
            {
                var jobEntity = _mapper.Map<Job>(jobDTO);
                jobEntity.Id = jobDTO.Id;
                await _jobRepository.UpdateJob(jobEntity);

                return new MessageResponseDTO(true, "Vaga criada com sucesso");
            }
            catch (Exception ex)
            {
                return new MessageResponseDTO(false, ex.Message);
            }
        }

        public async Task<MessageResponseDTO> DeleteJob(long id)
        {
            bool existsJob = await _jobRepository.ExistsById(id);
            if (!existsJob)
            {
                return new MessageResponseDTO(false, "Vaga não encontrada");
            }

            await _jobRepository.DeleteJob(id);
            return new MessageResponseDTO(true, "Vaga deletada com sucesso");
        }
    }
}
