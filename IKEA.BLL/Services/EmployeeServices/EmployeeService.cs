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
    public class EmployeeService(EmployeeRepository employeeRepository):IEmployeeService
    {
        private readonly EmployeeRepository _employeeRepository = employeeRepository;
        public IEnumerable<EmployeeDto> GetAll()
        {

            var Employees= _employeeRepository.GetAll();
            var EmployeesToBeReturned = Employees.Select(E=>new EmployeeDto()
            {
                Id= E.Id,
                Name= E.Name,
                Age= E.Age,
                Salary= E.Salary,
                email=E.email,
                gender= E.gender,
                Address=E.Address,
                IsActive= E.IsActive,
                EmployeeType= E.EmployeeType
            });
            return EmployeesToBeReturned;
        }


        public EmployeeDetailsDto? GetById(int id)
        {
           var employee= _employeeRepository.GetById(id);
           if (employee == null)
                return null;
           return employee.ToEmployeeDetailsDto();
            
        }

        public int Create(CreatedEmployeeDto createdEmployeeDto)
        {
            var employee = createdEmployeeDto.ToEntity();
            int Result=_employeeRepository.Add(employee);
            if (Result > 0)
                return Result;
            else return 0;
        }

        public bool Delete(int id)
        {
            var employee=_employeeRepository.GetById(id);
            if(employee == null) return false;
            else
            {
                int result=_employeeRepository.Remove(employee);
                if(result > 0) return true;
                else return false;
            }
           
        }    

        public int Update(UpdatedEmployeeDto dto)
        {
            var employee=dto.ToEntity();
            int result=_employeeRepository.Update(employee);
            if(result > 0) return result;
            else return 0;
            
        }
    }
}
