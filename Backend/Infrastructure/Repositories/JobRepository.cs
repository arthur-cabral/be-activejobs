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
            return PagedList<Job>.ToPagedList(Get().OrderByDescending(on => on.DateCreated),
                paginationParameters.PageNumber, paginationParameters.PageSize);
        }

        public async Task<PagedList<Job>> GetAllActive(PaginationParameters paginationParameters)
        {
            return PagedList<Job>.ToPagedList(Get().Where(j => j.Active == true).OrderByDescending(on => on.DateCreated),
                paginationParameters.PageNumber, paginationParameters.PageSize);
        }

        public async Task<Job> GetById(long id)
        {
            return await GetByProperty(j => j.Id == id);
        }

        public async Task<bool> ExistsById(long id)
        {
            Job job = await GetByProperty(j => j.Id == id);
            return job != null;
        }

        public async Task CreateJob(Job job)
        {
            Add(job);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateJob(Job job)
        {
            Update(job);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteJob(long id)
        {
            Job job = await GetByProperty(j => j.Id == id);
            Delete(job);
            await _context.SaveChangesAsync();
        }
    }
}
