using Domain.Entities;
using Domain.Interfaces;
using Domain.Pagination;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Infrastructure.Repositories
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        public JobRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<PagedList<Job>> GetAll(PaginationParameters paginationParameters)
        {
            return PagedList<Job>.ToPagedList(Get().OrderBy(on => on.Title),
                paginationParameters.PageNumber, paginationParameters.PageSize);
        }
    }
}
