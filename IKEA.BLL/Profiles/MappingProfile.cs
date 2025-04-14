using AutoMapper;
using IKEA.BLL.DTO.EmployeeDTO_s;
using IKEA.DAL.Models.EmployeeModels;
using IKEA.DAL.Models.Shared.enums;
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
                .ForMember(dest => dest.EmpType, Options => Options.MapFrom(src => src.EmployeeType));


            CreateMap<Employee, EmployeeDetailsDto>()
            .ForMember(dest => dest.gender, opt => opt.MapFrom(src => src.gender.ToString()))
            .ForMember(dest => dest.EmployeeType, opt => opt.MapFrom(src => src.EmployeeType.ToString()))
            .ForMember(dest => dest.HiringDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)))
            .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.CreatedOn)))
            .ForMember(dest => dest.LastMoifiedOn, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.LastMoifiedOn)));


            CreateMap<CreatedEmployeeDto, Employee>()
                .ForMember(dest => dest.gender, Options => Options.MapFrom(src => Enum.Parse<Gender>(src.gender)))
                .ForMember(dest => dest.EmployeeType, Options => Options.MapFrom(src => Enum.Parse<EmployeeType>(src.EmployeeType)))
                .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));


            CreateMap<UpdatedEmployeeDto, Employee>()
                 .ForMember(dest => dest.gender, Options => Options.MapFrom(src => src.gender))
                .ForMember(dest => dest.EmployeeType, Options => Options.MapFrom(src => src.gender))
                .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));
        }
    }
}
