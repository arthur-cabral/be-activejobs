using Application.DTO.Job;
using Application.DTO.Pagination;
using AutoMapper;
using Domain.Entities;
using Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Job, JobDTO>().ReverseMap();
            CreateMap<PaginationParameters, PaginationParametersDTO>().ReverseMap();
        }
    }
}
