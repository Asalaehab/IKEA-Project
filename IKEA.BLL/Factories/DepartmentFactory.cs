using IKEA.BLL.DTO;
using IKEA.DAL.Models.DepartmentsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Factories
{
    public static class DepartmentFactory
    {
        public static DepartmentDto ToDepartmentDTO(this Department D)
        {
            return new DepartmentDto()
            {
                DeptId = D.Id,
                Code = D.Code,
                Name = D.Name,
                Description = D.Description,
                DateOfCreation = DateOnly.FromDateTime(D.CreatedOn)
            };
        }


        public static DepartmentDetailsDTO ToDepartmentDetailsDto(this Department department)
        {
            return new DepartmentDetailsDTO()
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                CreatedOn = DateOnly.FromDateTime(department.CreatedOn),
                LastMoifiedOn = DateOnly.FromDateTime(department.LastMoifiedOn),
                CreatedBy = department.CreatedBy,
                LastModifiedBy = department.LastModifiedBy
            };
        }

        public static Department ToEntity(this CreatedDepartmentDto departmentDto)
        {
            return new Department()
            {
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                Description = departmentDto.Description,
                CreatedOn = departmentDto.DateOfCreation.ToDateTime(new TimeOnly())
            };
        }

        public static Department ToEntity(this UpdatedDepartmentDto departmentdto) => new Department()
        {
            Name = departmentdto.Name,
            Code = departmentdto.Code,
            Id = departmentdto.Id,
            Description = departmentdto.Description,
            CreatedOn = departmentdto.DateOfCreation.ToDateTime(new TimeOnly())

        };
      

    }
}
