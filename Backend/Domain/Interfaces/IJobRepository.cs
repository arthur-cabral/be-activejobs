using Domain.Entities;
using Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IJobRepository : IRepository<Job>
    {
        Task<PagedList<Job>> GetAll(PaginationParameters paginationParameters);
    }
}
