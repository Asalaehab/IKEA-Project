using IKEA.BLL.DTO.EmployeeDTO_s;
using IKEA.BLL.Factories;
using IKEA.DAL.Models.EmployeeModels;
using IKEA.DAL.Persintance.Reposatories.classes;
using IKEA.DAL.Persintance.Reposatories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services.EmployeeServices
{
    public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;



        public IEnumerable<EmployeeDto> GetAll(bool WithTracking)
        {
            var Employees = _employeeRepository.GetAll();
            var EmployeesToReturn = Employees.Select(E => new EmployeeDto()
            {
                Id = E.Id,
                Name = E.Name,
                Address = E.Address,
                Age = E.Age,
                Salary = E.Salary,
                email = E.email,
                IsActive = E.IsActive,
                PhoneNumber = E.PhoneNumber,
                EmployeeType = E.EmployeeType.ToString(),
                gender = E.gender.ToString()

            });


            return EmployeesToReturn;
        }



        public EmployeeDetailsDto? GetById(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee == null) return null;
            return new EmployeeDetailsDto()
            {
                Name = employee.Name,
                Address = employee.Address,
                Age = employee.Age,
                Salary = employee.Salary,
                PhoneNumber = employee.PhoneNumber,
                email = employee.email,
                IsActive = employee.IsActive,
                gender = employee.gender.ToString(),
                EmployeeType = employee.EmployeeType.ToString(),
                HiringDate = DateOnly.FromDateTime(employee.HiringDate),
                CreatedBy = 1,
                LastModifiedBy = 1,

                
            };
        }


        public int Create(CreatedEmployeeDto createdEmployeeDto)
        {
            throw new NotImplementedException();

        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

      

        public int Update(UpdatedEmployeeDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
