using AutoMapper;
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
    public class EmployeeService(IEmployeeRepository employeeRepository,IMapper _mapper) : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;

        

        public IEnumerable<EmployeeDto> GetAll(string? EmployeeSearchName)
        {
      

            ////Src        =>Dest
            ////Employee  => EmployeeDto
            
            IEnumerable<Employee> employees;
            if (string.IsNullOrWhiteSpace(EmployeeSearchName))
            {
                employees = _employeeRepository.GetAll();
            }
            else
            {  
                employees = _employeeRepository.GetAll(E => E.Name.ToLower().Contains(EmployeeSearchName));
            }
            var employeeDto = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
            return employeeDto;

        }



        public EmployeeDetailsDto? GetById(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee == null) { return null; }
           return _mapper.Map<Employee,EmployeeDetailsDto>(employee);
        }


        public int Create(CreatedEmployeeDto createdEmployeeDto)
        {

            var emp = _mapper.Map<CreatedEmployeeDto, Employee>(createdEmployeeDto);
            return _employeeRepository.Add(emp);
        }

      

      

        public int Update(UpdatedEmployeeDto dto)
        {
            return _employeeRepository.Update(_mapper.Map<UpdatedEmployeeDto, Employee>(dto));  
        }

        public bool Delete(int id)
        {
            var employee=_employeeRepository.GetById(id);
            if (employee == null) { return false; }
            else
            {
                employee.IsDeleted = true;
                return _employeeRepository.Update(employee) > 0 ? true : false;
            }
        }

        public IEnumerable<EmployeeDto> GetAll(bool WithTracking = false)
        {
            throw new NotImplementedException();
        }
    }
}
