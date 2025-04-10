using IKEA.BLL.DTO.EmployeeDTO_s;
using IKEA.DAL.Models.EmployeeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Factories
{
    public static class EmployeeFactory
    {
        public static EmployeeDetailsDto ToEmployeeDetailsDto(this Employee employee)
        {
            var employeedetailsDto = new EmployeeDetailsDto()
            {
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                IsActive= employee.IsActive,
                Salary = employee.Salary,
                email=employee.email,
                PhoneNumber = employee.PhoneNumber,
                gender=employee.gender,
                EmployeeType = employee.EmployeeType,
                HiringDate=DateOnly.FromDateTime(employee.HiringDate)
            };
            return employeedetailsDto;
        }


        public static Employee ToEntity(this CreatedEmployeeDto dto)
        {
            var DTO = new Employee()
            {
                Name = dto.Name,
                Age = dto.Age,
                Address = dto.Address,
                IsActive = dto.IsActive,
                Salary = dto.Salary,
                PhoneNumber= dto.PhoneNumber,

            };
            return DTO;
        }  
        public static Employee ToEntity(this UpdatedEmployeeDto dto)
        {
            var DTO = new Employee()
            {
                Name = dto.Name,
                Age = dto.Age,
                Address = dto.Address,
                IsActive = dto.IsActive,
                Salary = dto.Salary,
                PhoneNumber= dto.PhoneNumber,

            };
            return DTO;
        }

    }
}
