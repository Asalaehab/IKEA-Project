using AutoMapper;
using IKEA.BLL.DTO.EmployeeDTO_s;
using IKEA.DAL.Models.EmployeeModels;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.gender, Options => Options.MapFrom(src => src.gender))
                .ForMember(dest => dest.EmpType, Options => Options.MapFrom(src => src.gender));
            CreateMap<Employee, EmployeeDetailsDto>()
                 .ForMember(dest => dest.gender, Options => Options.MapFrom(src => src.gender))
                .ForMember(dest => dest.EmployeeType, Options => Options.MapFrom(src => src.gender))
                .ForMember(dest => dest.HiringDate, Options => Options.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)));

            CreateMap<CreatedEmployeeDto, Employee>()
                .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));
                        
            
            CreateMap<UpdatedEmployeeDto, Employee>();
        }


    }
}
