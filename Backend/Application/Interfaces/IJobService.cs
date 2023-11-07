using Application.DTO.Job;
using Application.DTO.Pagination;
using Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IJobService
    {
        Task<PagedList<JobDTO>> GetAll(PaginationParametersDTO paginationParametersDTO);
        Task<PagedList<JobDTO>> GetAllActive(PaginationParametersDTO paginationParametersDTO);
        Task<JobDTO> GetById(long id);
    }
}
